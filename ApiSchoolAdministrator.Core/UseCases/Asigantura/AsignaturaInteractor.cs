using ApiSchoolAdministrator.Core.Entities;
using ApiSchoolAdministrator.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiSchoolAdministrator.Core.UseCases.Asigantura
{
    public class AsignaturaInteractor : IAsignaturaInteractor
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AsignaturaInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }

        public Response AssignSubjectTeacher(string codigo, int? idProfesor)
        {
            EntityState result;
            try
            {
                var entity = _repositoryWrapper.Asignatura.FindByCondition(x => x.Codigo.Equals(codigo)).FirstOrDefault();
                entity.IdProfesor = idProfesor;
                
                result = _repositoryWrapper.Asignatura.Update(entity, "Codigo");
                //_repositoryWrapper.Save();
                return result == EntityState.Modified ?
                        new Response() { Status = 200, Message = "Asignación realizada con éxito", Payload = null } :
                        new Response() { Status = 400, Message = "No se pudo asignar el profesor", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }

        public Response GetReportGradebook()
        {
            try
            {
                var report = _repositoryWrapper.Asignatura.GetReportGradebook().ToList();

                return report.Any() ?
                    new Response() { Status = 200, Message = "Ok", Payload = report } :
                    new Response() { Status = 204, Message = "No content", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }

        public Response GetSubjects()
        {
            try
            {
                var subject = _repositoryWrapper.Asignatura
                    .FindAll()
                    .Include(x => x.Persona)
                    .Select(x => new Asignatura()
                    {
                        Codigo = x.Codigo,
                        Nombre = x.Nombre,
                        IdProfesor = x.IdProfesor,
                        Persona = new Entities.Persona() {
                            Id = x.Persona.Id,
                            Identificacion = x.Persona.Identificacion,
                            Nombre =  x.Persona.Nombre,
                            Apellido = x.Persona.Apellido
                        }
                    }); 

                return subject.Any() ?
                    new Response() { Status = 200, Message = "Ok", Payload = subject } :
                    new Response() { Status = 204, Message = "No content", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }

        public Response InsertStudentSubject(AlumnoAsignatura alumnoAsignatura)
        {
            try
            {
                if(_repositoryWrapper.AlumnoAsignatura.HasSubjectYear(alumnoAsignatura.IdAlumno, alumnoAsignatura.Anio))
                    return new Response() { 
                        Status = 202, 
                        Message = $"Él alumno ya tiene una asignación para el año {alumnoAsignatura.Anio}", 
                        Payload = null 
                    };

                var entity = _repositoryWrapper.AlumnoAsignatura.Create(alumnoAsignatura);

                return entity.IdAlumno >= 0 ?
                     new Response() { Status = 201, Message = "Asignación exitosa", Payload = alumnoAsignatura } :
                     new Response() { Status = 202, Message = "No se pudo realizar la asignación", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }

        public Response InsertSubject(Asignatura asignatura)
        {
            try
            {
                var entity = _repositoryWrapper.Asignatura.Create(asignatura);
                // _repositoryWrapper.Save();

                return entity.Codigo.Length >= 0 ?
                     new Response() { Status = 201, Message = "Asignatura creada con éxito", Payload = asignatura.Codigo } :
                     new Response() { Status = 400, Message = "No se pudo crear la asignatura", Payload = null };
            }
            catch (Exception e)
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }
    }
}
