namespace MyShuttle.Web.AppBuilderExtensions
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class DataContextExtensions
    {
        public static IServiceCollection ConfigureDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
                throw new Exception("configuration is null");

            var runningOnMono = Type.GetType("Mono.Runtime") != null;
            var configInMemory = configuration["Data:UseInMemoryStore"] != null && configuration["Data:UseInMemoryStore"].Equals("true", StringComparison.OrdinalIgnoreCase);
            bool useInMemoryStore = runningOnMono || configInMemory;

            var connectionStrging = configuration["Data:DefaultConnection:ConnectionString"];
            if (useInMemoryStore || string.IsNullOrEmpty(connectionStrging))
            {
                

                services.AddEntityFrameworkInMemoryDatabase()
                  .AddDbContext<MyShuttleContext>(options =>
                  {
                      options.UseInMemoryDatabase("Hello");
                  });
            }
            else
            {
                services.AddEntityFrameworkSqlServer()
                   .AddDbContext<MyShuttleContext>(options =>
                   {
                       options.UseSqlServer(connectionStrging);
                   });
            }

            return services;
        }
    }
}