using Caret.Legal.Microservice.Repository.Mongo;

namespace Caret.Legal.Microservice.Repository;

public static class RepositoryExtensions
{
  public static void AddRepositories(this IServiceCollection services)
  {
    services.AddScoped<IProductRepository, ProductRepositoryMongo>();
  }
}
