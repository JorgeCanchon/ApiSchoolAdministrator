using ApiSchoolAdministrator.Core.Entities;
using ApiSchoolAdministrator.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public Response GetStudent() 
        {
            try
            {
                var student = _repositoryWrapper.Persona.FindByCondition(x => x.Rol == 1);

                return student.Any() ?
                    new Response() { Status = 200, Message = "Ok", Payload = student }:
                    new Response() { Status = 204, Message = "No content", Payload = null };
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

                return teachers.Any() ? 
                    new Response() { Status = 200, Message = "Ok", Payload = teachers } :
                    new Response() { Status = 204, Message = "No content", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }

        public Response InsertPerson(Entities.Persona person)
        {
            try
            {
                var entity = _repositoryWrapper.Persona.Create(person);
               // _repositoryWrapper.Save();

                return entity.Id >= 0 ?
                     new Response() { Status = 201, Message = "Persona creada con éxito", Payload = person.Id } :
                     new Response() { Status = 400, Message = "No se pudo crear la persona", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }

        public Response UpdatePerson(Entities.Persona person)
        {
            EntityState result;
            try
            {
                result = _repositoryWrapper.Persona.Update(person, "Id");
                //_repositoryWrapper.Save();
                return result == EntityState.Modified ?
                        new Response() { Status = 200, Message = "Persona modificada con éxito", Payload = null } :
                        new Response() { Status = 400, Message = "No se pudo modificar la persona", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }

        public Response DeletePerson(long Id)
        {
            try
            {
                var entity = _repositoryWrapper.Persona
                            .FindByCondition(x => x.Id == Id)
                            .FirstOrDefault();

                if(entity == null)
                   return new Response() { Status = 400, Message = "No se pudo eliminar la persona", Payload = null };

                var result = _repositoryWrapper.Persona.Delete(entity);
                _repositoryWrapper.Save();

                return result == EntityState.Deleted ?
                       new Response() { Status = 200, Message = "Persona eliminada con éxito", Payload = entity.Id } :
                       new Response() { Status = 400, Message = "No se pudo eliminar la persona", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }
    }
}
