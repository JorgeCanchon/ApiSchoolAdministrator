using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSchoolAdministrator.Core.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IPersonaRepository Persona { get; }
        IAsignaturaRepository Asignatura { get; }
        IAlumnoAsignatura AlumnoAsignatura { get; }
        void Save();
    }
}
