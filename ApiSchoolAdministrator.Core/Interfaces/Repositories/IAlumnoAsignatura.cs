using ApiSchoolAdministrator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSchoolAdministrator.Core.Interfaces.Repositories
{
    public interface IAlumnoAsignatura : IRepositoryBase<AlumnoAsignatura>
    {
        bool HasSubjectYear(int id, int year);
    }
}
