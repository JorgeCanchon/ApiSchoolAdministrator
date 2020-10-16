using ApiSchoolAdministrator.Core.Interfaces;
using ApiSchoolAdministrator.Infraestructure.Data.EntityFrameworkSqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSchoolAdministrator.Infraestructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMyPostgreSQLContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RepositoryContextSqlServer>(
                   options => options.UseSqlServer(config.GetConnectionString("SqlServerDBContext"), npgsqlOptions => {
                       npgsqlOptions.CommandTimeout(60);
                   })
               );
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
