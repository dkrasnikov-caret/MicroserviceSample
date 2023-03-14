using Caret.Legal.Microservice.Model;
using Caret.Legal.Microservice.Model.Infrastructure;
using Caret.Legal.Microservice.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Caret.Legal.Microservice.Controllers;

[ApiController]
[AllowAnonymous]
[Route("product")]
public class ProductController : ControllerBase
{
  private readonly ILogger<ProductController> _logger;
  private readonly IProductRepository _productRepository;

  public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
  {
    _logger = logger;
    _productRepository = productRepository;
  }


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
}
