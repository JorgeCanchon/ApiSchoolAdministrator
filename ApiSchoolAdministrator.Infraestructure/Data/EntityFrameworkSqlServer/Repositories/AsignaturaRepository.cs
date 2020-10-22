using ApiSchoolAdministrator.Core.Entities;
using ApiSchoolAdministrator.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace ApiSchoolAdministrator.Infraestructure.Data.EntityFrameworkSqlServer.Repositories
{
    public class AsignaturaRepository : RepositoryBase<Asignatura>, IAsignaturaRepository
    {
        private readonly RepositoryContextSqlServer _repositoryContextSqlServer;
        public AsignaturaRepository(RepositoryContextSqlServer repositoryContextSqlServer)
            : base(repositoryContextSqlServer)
        {
            _repositoryContextSqlServer = repositoryContextSqlServer ?? throw new ArgumentNullException(nameof(repositoryContextSqlServer));
        }

        public IQueryable<ReportGradebookViewModel> GetReportGradebook()
        {
            return _repositoryContextSqlServer.ReportGradebook.FromSqlRaw<ReportGradebookViewModel>("EXEC [dbo].[GetGradeBook]").AsNoTracking();
        }
    }
}
