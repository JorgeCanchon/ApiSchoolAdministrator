using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSchoolAdministrator.Core.Entities
{
    public class ReportGradebookViewModel
    {
		public int AñoAcademico { get; set; }
		public long IdentificacionAlumno { get; set; }
		public string NombreAlumno { get; set; }
		public string Codigo { get; set; }
		public string  Nombre { get; set; }
		public long IdentificacionProfesor { get; set; }
		public string NombreProfesor { get; set; } 
		public float Calificacion { get; set; }
		public string Aprobo { get; set; } 
	}
}
