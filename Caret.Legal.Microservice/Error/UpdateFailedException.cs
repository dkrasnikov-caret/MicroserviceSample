namespace Caret.Legal.Microservice.Error;

/// <summary>
/// DB update failed exception.
/// </summary>
/// <seealso cref="System.Exception" />
public class UpdateFailedException : Exception
{
  /// <summary>
  /// Initializes a new instance of the <see cref="UpdateFailedException"/> class.
  /// </summary>
  /// <param name="productName">Name of the product.</param>
  /// <param name="id">The identifier.</param>
  public UpdateFailedException(string productName, string id) : base($"Update failed {productName}:{id}")
  {
  }
}
