using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSchoolAdministrator.Core.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IPersonaRepository Persona { get; }
        void Save();
    }
}
