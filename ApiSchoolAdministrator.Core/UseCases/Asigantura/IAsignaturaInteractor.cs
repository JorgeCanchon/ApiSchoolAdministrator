using ApiSchoolAdministrator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSchoolAdministrator.Core.UseCases.Asigantura
{
    public interface IAsignaturaInteractor
    {
        Response GetSubjects();
        Response InsertSubject(Asignatura asignatura);
        Response InsertStudentSubject(AlumnoAsignatura alumnoAsignatura);
        Response AssignSubjectTeacher(string codigo, int? idProfesor);
        Response GetReportGradebook();
    }
}
