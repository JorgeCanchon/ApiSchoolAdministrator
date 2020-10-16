using ApiSchoolAdministrator.Core.Interfaces.Repositories;
using ApiSchoolAdministrator.Infraestructure.Data.EntityFrameworkSqlServer;
using Autofac;

namespace ApiSchoolAdministrator.Infraestructure
{
    public class InfraestructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryWrapper>().As<IRepositoryWrapper>().InstancePerLifetimeScope();
        }
    }
}
