namespace Caret.Legal.Microservice.Error;

/// <summary>
/// DB delete failed exception.
/// </summary>
/// <seealso cref="System.Exception" />
public class DeleteFailedException : Exception
{
  /// <summary>
  /// Initializes a new instance of the <see cref="DeleteFailedException"/> class.
  /// </summary>
  /// <param name="productName">Name of the product.</param>
  /// <param name="id">The identifier.</param>
  public DeleteFailedException(string productName, string id) : base($"Delete failed for {productName}:{id}")
  {
  }
}
