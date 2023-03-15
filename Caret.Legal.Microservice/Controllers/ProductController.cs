using Caret.Legal.Microservice.Model;
using Caret.Legal.Microservice.Model.Infrastructure;
using Caret.Legal.Microservice.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Caret.Legal.Microservice.Controllers;

/// <summary>
/// Product api
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
[ApiController]
[AllowAnonymous] //For development only.
[Route("product")]
public class ProductController : ControllerBase
{
  private readonly ILogger<ProductController> _logger;
  private readonly IProductRepository _productRepository;

  /// <summary>
  /// Initializes a new instance of the <see cref="ProductController"/> class.
  /// </summary>
  /// <param name="logger">The logger.</param>
  /// <param name="productRepository">The product repository.</param>
  public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
  {
    _logger = logger;
    _productRepository = productRepository;
  }


  /// <summary>
  /// Get the product.
  /// </summary>
  /// <param name="id">The identifier.</param>
  /// <param name="token">The token.</param>
  /// <returns></returns>
  [HttpGet("{id}", Name = "GetProduct")]
  [SwaggerOperation("CreateCase")]
  [SwaggerResponse(statusCode: 200, type: typeof(Product), description: "Product")]
  [SwaggerResponse(statusCode: 400, type: typeof(Api400Response), description: "BadRequest")]
  [SwaggerResponse(statusCode: 401, description: "AuthenticationError")]
  [SwaggerResponse(statusCode: 403, description: "AuthorizationError")]
  [SwaggerResponse(statusCode: 404, description: "NotFoundError")]
  [SwaggerResponse(statusCode: 500, description: "GenericError")]
  public async ValueTask<IActionResult> GetProduct(string id, CancellationToken token)
  {
    return Ok(await _productRepository.FindOneByIdAsync(id, token));
  }

  /// <summary>
  /// Gets all the products.
  /// </summary>
  /// <param name="token">The token.</param>
  /// <returns></returns>
  [SwaggerOperation("GetProducts")]
  [SwaggerResponse(statusCode: 200, type: typeof(IEnumerable<Product>), description: "Products")]
  [SwaggerResponse(statusCode: 400, type: typeof(Api400Response), description: "BadRequest")]
  [SwaggerResponse(statusCode: 401, description: "AuthenticationError")]
  [SwaggerResponse(statusCode: 403, description: "AuthorizationError")]
  [SwaggerResponse(statusCode: 404, description: "NotFoundError")]
  [SwaggerResponse(statusCode: 500, description: "GenericError")]
  [HttpGet("", Name = "GetProducts")]
  public async ValueTask<IActionResult> GetProducts(CancellationToken token)
  {
    return Ok(await _productRepository.FindAllAsync(token));
  }

  /// <summary>
  /// Creates the product.
  /// </summary>
  /// <param name="product">The product.</param>
  /// <param name="token">The token.</param>
  /// <returns></returns>
  [SwaggerOperation("CreateProduct")]
  [SwaggerResponse(statusCode: 201, type: typeof(string), description: "Products")]
  [SwaggerResponse(statusCode: 400, type: typeof(Api400Response), description: "BadRequest")]
  [SwaggerResponse(statusCode: 401, description: "AuthenticationError")]
  [SwaggerResponse(statusCode: 403, description: "AuthorizationError")]
  [SwaggerResponse(statusCode: 404, description: "NotFoundError")]
  [SwaggerResponse(statusCode: 500, description: "GenericError")]
  [HttpPost("", Name = "CreateProduct")]
  public async ValueTask<IActionResult> CreateProduct(Product product, CancellationToken token)
  {
    product.Id ??= Guid.NewGuid().ToString();
    await _productRepository.InsertAsync(product, token);
    return Created(product.Id, product);
  }

  /// <summary>
  /// Updates the product.
  /// </summary>
  /// <param name="id">The identifier.</param>
  /// <param name="product">The product.</param>
  /// <param name="token">The token.</param>
  /// <returns></returns>
  [SwaggerOperation("UpdateProduct")]
  [SwaggerResponse(statusCode: 204)]
  [SwaggerResponse(statusCode: 400, type: typeof(Api400Response), description: "BadRequest")]
  [SwaggerResponse(statusCode: 401, description: "AuthenticationError")]
  [SwaggerResponse(statusCode: 403, description: "AuthorizationError")]
  [SwaggerResponse(statusCode: 404, description: "NotFoundError")]
  [SwaggerResponse(statusCode: 500, description: "GenericError")]
  [HttpPut("{id}", Name = "UpdateProduct")]
  public async ValueTask<IActionResult> UpdateProduct(string id, Product product, CancellationToken token)
  {
    await _productRepository.UpdateAsync(id, product, token);
    return NoContent();
  }

  /// <summary>
  /// Deletes the product.
  /// </summary>
  /// <param name="id">The identifier.</param>
  /// <param name="token">The token.</param>
  /// <returns></returns>
  [SwaggerOperation("DeleteProduct")]
  [SwaggerResponse(statusCode: 204)]
  [SwaggerResponse(statusCode: 400, type: typeof(Api400Response), description: "BadRequest")]
  [SwaggerResponse(statusCode: 401, description: "AuthenticationError")]
  [SwaggerResponse(statusCode: 403, description: "AuthorizationError")]
  [SwaggerResponse(statusCode: 404, description: "NotFoundError")]
  [SwaggerResponse(statusCode: 500, description: "GenericError")]
  [HttpPut("{id}", Name = "DeleteProduct")]
  public async ValueTask<IActionResult> DeleteProduct(string id, CancellationToken token)
  {
    await _productRepository.DeleteAsync(id, token);
    return NoContent();
  }
}
