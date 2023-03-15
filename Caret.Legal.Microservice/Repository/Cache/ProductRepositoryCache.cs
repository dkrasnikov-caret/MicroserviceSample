using Caret.Legal.Microservice.Model;
using Caret.Legal.Microservice.Repository.Mongo;
using Caret.Legal.Microservice.Service;

namespace Caret.Legal.Microservice.Repository.Cache;

public class ProductRepositoryCache: IProductRepository
{
  private readonly ProductRepositoryMongo _target;
  private readonly ICacheService<Product> _cacheService;

  public ProductRepositoryCache(ProductRepositoryMongo target, ICacheService<Product> cacheService)
  {
    _target = target;
    _cacheService = cacheService;
  }

  #region Implementation of IProductRepository

  /// <inheritdoc />
  public async ValueTask<Product> FindOneByIdAsync(string id, CancellationToken token)
  {
    return await _cacheService.GetOrCreateAsync(id, () => _target.FindOneByIdAsync(id, token), token);
  }

  /// <inheritdoc />
  public ValueTask InsertAsync(Product product, CancellationToken token)
  {
    return _target.InsertAsync(product, token);
  }

  /// <inheritdoc />
  public async ValueTask UpdateAsync(string id, Product product, CancellationToken token)
  {
    await _target.UpdateAsync(id, product, token);
    await _cacheService.Invalidate(id, token);
  }

  /// <inheritdoc />
  public async ValueTask DeleteAsync(string id, CancellationToken token)
  {
    await _target.DeleteAsync(id, token);
    await _cacheService.Invalidate(id, token);
  }

  /// <inheritdoc />
  public ValueTask<IEnumerable<Product>> FindAllAsync(CancellationToken token)
  {
    return _target.FindAllAsync(token);
  }

  #endregion
}
