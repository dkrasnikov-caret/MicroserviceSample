using Caret.Legal.Microservice.Model;
using MongoDB.Driver;
using Caret.Legal.Microservice.Error;

namespace Caret.Legal.Microservice.Repository.Mongo;

public class ProductRepositoryMongo: IProductRepository
{
  protected FilterDefinitionBuilder<Product> FilterBuilder => Builders<Product>.Filter;

  private readonly IMongoCollection<Product> _collection;

  public ProductRepositoryMongo(IConfiguration configuration)
  {
    var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
    _collection = client.GetDatabase("Microservice").GetCollection<Product>(nameof(Product));
  }

  /// <inheritdoc />
  public async ValueTask<Product> FindOneByIdAsync(string id, CancellationToken token)
  {
    Thread.Sleep(3000);
    var options = new FindOptions<Product> {Limit=1};
    var asyncCursor = await _collection.FindAsync(FilterBuilder.Eq("_id", id), options, token);
    return asyncCursor.FirstOrDefault();
  }

  /// <inheritdoc />
  public async ValueTask InsertAsync(Product product, CancellationToken token)
  {
    await _collection.InsertOneAsync(product, null, token);
  }

  /// <inheritdoc />
  public async ValueTask UpdateAsync(string id, Product product, CancellationToken token)
  {
    var options = new ReplaceOptions {IsUpsert=false};
    var result = await _collection.ReplaceOneAsync(FilterBuilder.Eq("_id", id), product, options, token);
    if(result.MatchedCount <= 0) throw new FindFailedException(nameof(Product), id);
    if(result.ModifiedCount <= 0) throw new UpdateFailedException(nameof(Product), id);
  }

  /// <inheritdoc />
  public async ValueTask DeleteAsync(string id, CancellationToken token)
  {
    var result = await _collection.DeleteOneAsync(FilterBuilder.Eq("_id", id), token);
    if(result.DeletedCount <= 0) throw new DeleteFailedException(nameof(Product), id);
  }

  /// <inheritdoc />
  public async ValueTask<IEnumerable<Product>> FindAllAsync(CancellationToken token)
  {
    var asyncCursor = await _collection.FindAsync(FilterBuilder.Empty, null, token);
    return asyncCursor.ToEnumerable();
  }
}
