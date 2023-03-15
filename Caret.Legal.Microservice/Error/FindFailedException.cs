namespace Caret.Legal.Microservice.Error;

/// <summary>
/// DB find failed exception.
/// </summary>
/// <seealso cref="System.Exception" />
public class FindFailedException : Exception
{
  /// <summary>
  /// Initializes a new instance of the <see cref="FindFailedException"/> class.
  /// </summary>
  /// <param name="productName">Name of the product.</param>
  /// <param name="id">The identifier.</param>
  public FindFailedException(string productName, string id) : base($"Find failed for {productName}:{id}")
  {
  }
}
