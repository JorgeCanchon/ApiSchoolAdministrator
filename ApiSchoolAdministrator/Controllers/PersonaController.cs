using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSchoolAdministrator.Core.Entities;
using ApiSchoolAdministrator.Core.UseCases.Persona;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSchoolAdministrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
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
            switch (response.Status)
            {
                case 204:
                    return Ok(response);
                case 500:
                    return Problem(response.Message);
                default:
                    return NotFound(response);
            }
        }
    }
}