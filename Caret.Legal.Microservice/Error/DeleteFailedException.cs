namespace Caret.Legal.Microservice.Error;

public class DeleteFailedException : Exception
{
  public DeleteFailedException(string productName, string id) : base($"Delete failed for {productName}:{id}")
  {
  }
}
