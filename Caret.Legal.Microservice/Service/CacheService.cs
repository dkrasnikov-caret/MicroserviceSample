using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Caret.Legal.Microservice.Service;

public interface ICacheService<T>
{
  ValueTask<T> GetOrCreateAsync(string id, Func<ValueTask<T>> factory, CancellationToken token);
  ValueTask Invalidate(string id, CancellationToken token);
  string CacheEntryId(string id);
}

public class CacheService<T> : ICacheService<T>
{
  private readonly IDistributedCache _distributedCache;
  private readonly DistributedCacheEntryOptions _options;
  private readonly string _entity;

  public CacheService(IDistributedCache distributedCache)
  {
    _distributedCache = distributedCache;
    _options = new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30) };
    _entity = typeof(T).Name;
  }

  public string CacheEntryId(string id) => $"{_entity}_{id}";

  public async ValueTask<T> GetOrCreateAsync(string id, Func<ValueTask<T>> factory, CancellationToken token)
  {
    var json = await _distributedCache.GetStringAsync(CacheEntryId(id), token);
    if (json != null) return JsonSerializer.Deserialize<T>(json)!;
    var result = await factory();
    await _distributedCache.SetStringAsync(CacheEntryId(id), JsonSerializer.Serialize(result), _options, token);
    return result;
  }

  public async ValueTask Invalidate(string id, CancellationToken token)
  {
    await _distributedCache.RemoveAsync(CacheEntryId(id), token);
  }
}


