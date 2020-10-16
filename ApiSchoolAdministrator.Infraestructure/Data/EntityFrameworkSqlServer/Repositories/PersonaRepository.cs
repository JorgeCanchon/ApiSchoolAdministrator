using ApiSchoolAdministrator.Core;
using ApiSchoolAdministrator.Core.Entities;
using ApiSchoolAdministrator.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSchoolAdministrator.Infraestructure.Data.EntityFrameworkSqlServer.Repositories
{
    public class PersonaRepository : RepositoryBase<Persona>, IPersonaRepository
    {
        public PersonaRepository(RepositoryContextSqlServer repositoryContextSqlServer)
            : base(repositoryContextSqlServer)
        {

        }
    }
}
