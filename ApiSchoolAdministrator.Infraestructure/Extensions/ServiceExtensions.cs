using ApiSchoolAdministrator.Core.Interfaces.Repositories;
using ApiSchoolAdministrator.Infraestructure.Data.EntityFrameworkSqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiSchoolAdministrator.Infraestructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMySqlServerDBContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RepositoryContextSqlServer>(
                   options => options.UseSqlServer(config.GetConnectionString("SqlServerDBContext"), npgsqlOptions => {
                       npgsqlOptions.CommandTimeout(60);
                   }),
                   ServiceLifetime.Transient
               );
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
