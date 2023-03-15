namespace Caret.Legal.Microservice.Service;

public static class ServiceExtensions
{
  public static void AddServices(this IServiceCollection services)
  {
    services.AddTransient(typeof(ICacheService<>), typeof(CacheService<>));
  }
}
