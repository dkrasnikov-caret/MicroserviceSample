using Caret.Legal.Microservice.Model;

namespace Caret.Legal.Microservice.Repository;

public interface IProductRepository
{
  ValueTask<Product> FindOneByIdAsync(string id, CancellationToken token);
  ValueTask InsertAsync(Product product, CancellationToken token);
  ValueTask UpdateAsync(string id, Product product, CancellationToken token);
  ValueTask DeleteAsync(string id, CancellationToken token);
  ValueTask<IEnumerable<Product>> FindAllAsync(CancellationToken token);
}
