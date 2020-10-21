using Autofac;
using ApiSchoolAdministrator.Core.UseCases.Persona;
using ApiSchoolAdministrator.Core.UseCases.Asigantura;

namespace ApiSchoolAdministrator.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonaInteractor>().As<IPersonaInteractor>().SingleInstance();
            builder.RegisterType<AsignaturaInteractor>().As<IAsignaturaInteractor>().SingleInstance();
        }
    }
}
