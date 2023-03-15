namespace Caret.Legal.Microservice.Model;

/// <summary>
/// Product type
/// </summary>
/// <seealso cref="Caret.Legal.Microservice.Model.IId" />
public class Product: IId
{
  /// <summary>
  /// Gets or sets the identifier.
  /// </summary>
  /// <value>
  /// The identifier.
  /// </value>
  public string? Id { get; set; }
  /// <summary>
  /// Gets or sets the name.
  /// </summary>
  /// <value>
  /// The name.
  /// </value>
  public string? Name { get; set; }
  /// <summary>
  /// Gets or sets the price.
  /// </summary>
  /// <value>
  /// The price.
  /// </value>
  public int Price { get; set; }
}
