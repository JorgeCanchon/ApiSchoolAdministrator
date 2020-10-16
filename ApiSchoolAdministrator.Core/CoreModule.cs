using Autofac;
using ApiSchoolAdministrator.Core.UseCases.Persona;

namespace ApiSchoolAdministrator.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonaInteractor>().As<IPersonaInteractor>().SingleInstance();
        }
    }
}
