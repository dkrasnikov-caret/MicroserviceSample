namespace Caret.Legal.Microservice.Error;

public class FindFailedException : Exception
{
  public FindFailedException(string productName, string id) : base($"Find failed for {productName}:{id}")
  {
  }
}
