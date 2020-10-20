using ApiSchoolAdministrator.Core.Interfaces.Repositories;
using ApiSchoolAdministrator.Infraestructure.Data.EntityFrameworkSqlServer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSchoolAdministrator.Infraestructure.Data.EntityFrameworkSqlServer
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public IPersonaRepository persona;

        public IAsignaturaRepository asignatura;

        public IAlumnoAsignatura alumnoAsignatura;

        private readonly RepositoryContextSqlServer _repositoryContextSqlServer;

        public RepositoryWrapper(RepositoryContextSqlServer repositoryContextSqlServer)
        {
            _repositoryContextSqlServer = repositoryContextSqlServer ?? throw new ArgumentNullException(nameof(repositoryContextSqlServer));
        }
        public IPersonaRepository Persona
        {
            get
            {
                if (persona == null)
                    persona = new PersonaRepository(_repositoryContextSqlServer);
                return persona;
            }
        }

        public IAsignaturaRepository Asignatura
        {
            get
            {
                if (asignatura == null)
                    asignatura = new AsignaturaRepository(_repositoryContextSqlServer);
                return asignatura;
            }
        }

        public IAlumnoAsignatura AlumnoAsignatura
        {
            get
            {
                if (alumnoAsignatura == null)
                    alumnoAsignatura = new AlumnoAsignaturaRepository(_repositoryContextSqlServer);
                return alumnoAsignatura;
            }
        }

        public async void Save() => 
            await _repositoryContextSqlServer.SaveChangesAsync();
    }
}
