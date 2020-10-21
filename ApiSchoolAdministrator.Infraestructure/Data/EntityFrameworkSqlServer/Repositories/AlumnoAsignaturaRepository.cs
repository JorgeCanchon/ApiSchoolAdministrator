using ApiSchoolAdministrator.Core.Entities;
using ApiSchoolAdministrator.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiSchoolAdministrator.Infraestructure.Data.EntityFrameworkSqlServer.Repositories
{
    public class AlumnoAsignaturaRepository : RepositoryBase<AlumnoAsignatura>, IAlumnoAsignatura
    {
        private readonly RepositoryContextSqlServer _repositoryContextSqlServer;
        public AlumnoAsignaturaRepository(RepositoryContextSqlServer repositoryContextSqlServer)
            : base(repositoryContextSqlServer)
        {
            _repositoryContextSqlServer = repositoryContextSqlServer ?? throw new ArgumentNullException(nameof(repositoryContextSqlServer));
        }

        public bool HasSubjectYear(int id, int year)
        {
            return _repositoryContextSqlServer.AlumnoAsignatura.Where(x => x.IdAlumno == id && x.Anio == year).Any();
        }
    }
}
