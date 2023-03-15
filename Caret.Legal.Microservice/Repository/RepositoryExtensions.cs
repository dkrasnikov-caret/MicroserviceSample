using Caret.Legal.Microservice.Repository.Cache;
using Caret.Legal.Microservice.Repository.Mongo;

namespace Caret.Legal.Microservice.Repository;

public static class RepositoryExtensions
{
  public static void AddRepositories(this IServiceCollection services)
  {
    services.AddScoped<ProductRepositoryMongo, ProductRepositoryMongo>();
    services.AddScoped<IProductRepository, ProductRepositoryCache>();
  }
}
