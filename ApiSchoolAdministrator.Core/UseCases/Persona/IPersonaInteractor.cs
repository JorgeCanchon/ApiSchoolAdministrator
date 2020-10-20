using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiSchoolAdministrator.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiSchoolAdministrator.Core.UseCases.Persona
{
    public interface IPersonaInteractor
    {
        Response GetTeacher();
        Response GetStudent();
        Response InsertPerson(Entities.Persona person);
        Response UpdatePerson(Entities.Persona person);
        Response DeletePerson(int Id);
    }
}
