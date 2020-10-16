using ApiSchoolAdministrator.Core.Entities;
using ApiSchoolAdministrator.Core.Interfaces.Repositories;
using System;
using System.Linq;

namespace ApiSchoolAdministrator.Core.UseCases.Persona
{
    public class PersonaInteractor : IPersonaInteractor
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PersonaInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }
        public Response DeletePerson(long Id)
        {
            throw new NotImplementedException();
        }

        public Response GetStudent() 
        {
            try
            {
                var student = _repositoryWrapper.Persona.FindByCondition(x => x.Rol == 1);
                if (student.Any())
                    return new Response() { Status = 200, Message = "Ok", Payload = student };
                return new Response() { Status = 204, Message = "No content", Payload = null };
            }
            catch(Exception e) 
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }

        public Response GetTeacher() 
        {
            try
            {
                var teachers = _repositoryWrapper.Persona.FindByCondition(x => x.Rol == 0);
                if (teachers.Any())
                    return new Response() { Status = 200, Message = "Ok", Payload = teachers };
                return new Response() { Status = 204, Message = "No content", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }

        public Response InsertPerson(Entities.Persona person)
        {
            throw new NotImplementedException();
        }

        public Response UpdatePerson(Entities.Persona person)
        {
            throw new NotImplementedException();
        }
    }
}
