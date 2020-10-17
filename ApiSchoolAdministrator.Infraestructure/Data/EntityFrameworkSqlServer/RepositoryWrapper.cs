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

        public void Save() => 
            _repositoryContextSqlServer.SaveChanges();
    }
}
