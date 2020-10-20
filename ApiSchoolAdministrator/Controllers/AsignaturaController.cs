using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSchoolAdministrator.Common;
using ApiSchoolAdministrator.Core.Entities;
using ApiSchoolAdministrator.Core.UseCases.Asigantura;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSchoolAdministrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignaturaController : ApiController
    {
        private readonly IAsignaturaInteractor _asignaturaInteractor;

        public AsignaturaController(IAsignaturaInteractor asignaturaInteractor)
        {
            _asignaturaInteractor = asignaturaInteractor ?? throw new ArgumentNullException(nameof(asignaturaInteractor));
        }

        [HttpGet()]
        public IActionResult GetSubject()
        {
            Response response = _asignaturaInteractor.GetSubjects();
            return GetStatus(response.Status, response);
        }

        [HttpPost]
        public IActionResult Post(Asignatura asignatura)
        {
            Response response = _asignaturaInteractor.InsertSubject(asignatura);
            return GetStatus(response.Status, response);
        }

        [HttpPatch("{codigo}/{idProfesor}")]
        public IActionResult Patch(string codigo, int idProfesor)
        {
            Response response = _asignaturaInteractor.AssignSubjectTeacher(codigo, idProfesor);
            return GetStatus(response.Status, response);
        }

        [HttpPost("alumnoAsignatura")]
        public IActionResult Post(AlumnoAsignatura alumnoAsignatura)
        {
            Response response = _asignaturaInteractor.InsertStudentSubject(alumnoAsignatura);
            return GetStatus(response.Status, response);
        }
    }
}