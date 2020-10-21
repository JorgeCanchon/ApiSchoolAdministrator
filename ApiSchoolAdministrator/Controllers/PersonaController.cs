using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSchoolAdministrator.Common;
using ApiSchoolAdministrator.Core.Entities;
using ApiSchoolAdministrator.Core.UseCases.Persona;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ApiSchoolAdministrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ApiController
    {
        private readonly IPersonaInteractor _personaInteractor;

        public PersonaController(IPersonaInteractor personaInteractor)
        {
            _personaInteractor = personaInteractor ?? throw new ArgumentNullException(nameof(personaInteractor));
        }

        [HttpGet("teacher")]
        public IActionResult GetTeacher()
        {
            Response response = _personaInteractor.GetTeacher();
            return GetStatus(response.Status, response);
        }

        [HttpGet("student")]
        public IActionResult GetStudent()
        {
            Response response = _personaInteractor.GetStudent();
            return GetStatus(response.Status, response);
        }

        [HttpPost]
        public IActionResult Post(Persona persona)
        {
            Response response = _personaInteractor.InsertPerson(persona);
            return GetStatus(response.Status, response);
        }

        [HttpPut]
        public IActionResult Put(Persona person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Response response = _personaInteractor.UpdatePerson(person);
            return GetStatus(response.Status, response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Response response = _personaInteractor.DeletePerson(id);
            return GetStatus(response.Status, response);
        }
    }
}