using ApiSchoolAdministrator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiSchoolAdministrator.Core.Interfaces.Repositories
{
    public interface IAsignaturaRepository : IRepositoryBase<Asignatura>
    {
        IQueryable<ReportGradebookViewModel> GetReportGradebook();
    }
}
