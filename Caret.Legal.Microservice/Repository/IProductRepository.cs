using Caret.Legal.Microservice.Model;

namespace Caret.Legal.Microservice.Repository;

/// <summary>
/// Product repository.
/// </summary>
public interface IProductRepository
{
  /// <summary>
  /// Finds product by the one by identifier asynchronous.
  /// </summary>
  /// <param name="id">The identifier.</param>
  /// <param name="token">The token.</param>
  /// <returns>Product</returns>
  ValueTask<Product> FindOneByIdAsync(string id, CancellationToken token);
  /// <summary>
  /// Inserts the product asynchronous.
  /// </summary>
  /// <param name="product">The product.</param>
  /// <param name="token">The token.</param>
  /// <returns></returns>
  ValueTask InsertAsync(Product product, CancellationToken token);
  /// <summary>
  /// Updates the product asynchronous.
  /// </summary>
  /// <param name="id">The identifier.</param>
  /// <param name="product">The product.</param>
  /// <param name="token">The cancellation token.</param>
  /// <returns></returns>
  ValueTask UpdateAsync(string id, Product product, CancellationToken token);
  /// <summary>
  /// Deletes the product asynchronous.
  /// </summary>
  /// <param name="id">The identifier.</param>
  /// <param name="token">The token.</param>
  /// <returns></returns>
  ValueTask DeleteAsync(string id, CancellationToken token);
  /// <summary>
  /// Finds all products asynchronous.
  /// </summary>
  /// <param name="token">The token.</param>
  /// <returns></returns>
  ValueTask<IEnumerable<Product>> FindAllAsync(CancellationToken token);
}
