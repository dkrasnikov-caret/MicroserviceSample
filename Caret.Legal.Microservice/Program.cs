using System.Text;
using Caret.Legal.Microservice.Repository;
using Caret.Legal.Microservice.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Caret.Legal.Microservice;

/// <summary>
///   Main type.
/// </summary>
public class Program
{
  #region Public

  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    void ConfigureJwt(JwtBearerOptions options)
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
      };
    }

// Add services to the container.
    builder.Services
      .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(ConfigureJwt);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Adding local repositories to DI
    builder.Services.AddRepositories();
    // Adding local services to DI
    builder.Services.AddServices();
    //Adding Redis distributed cache provider
    builder.Services.AddStackExchangeRedisCache(options =>
    {
      options.Configuration = builder.Configuration.GetConnectionString("Redis");
      options.InstanceName = "Microservice";
    });

    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
  }

  #endregion
}
