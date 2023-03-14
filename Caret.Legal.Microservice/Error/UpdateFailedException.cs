namespace Caret.Legal.Microservice.Error;

public class UpdateFailedException : Exception
{
  public UpdateFailedException(string productName, string id) : base($"Update failed {productName}:{id}")
  {
  }
}
