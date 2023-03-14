namespace Caret.Legal.Microservice.Model;

public class Product: IId
{
  public string? Id { get; set; }
  public string? Name { get; set; }
  public int Price { get; set; }
}
