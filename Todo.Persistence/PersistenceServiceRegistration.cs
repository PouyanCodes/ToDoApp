
using Microsoft.EntityFrameworkCore;
using TodoApp.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Application.Contracts.Persistence;

namespace TodoApp.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
             IConfiguration configuration)
        {
            // Add DB Context

            services.AddDbContext<DataBaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });


            // Add Services

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ITodoRepository, TodoRepository>();

            return services;
        }
    }
}
