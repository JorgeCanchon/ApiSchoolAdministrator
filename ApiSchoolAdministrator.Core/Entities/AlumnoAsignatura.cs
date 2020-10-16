using System;
using System.Collections.Generic;

namespace ApiSchoolAdministrator.Core
{
    public partial class AlumnoAsignatura
    {
        public int IdAlumno { get; set; }
        public int IdProfesor { get; set; }
        public int Anio { get; set; }
        public string CodigoAsignatura { get; set; }
        public float Calificacion { get; set; }

        public virtual Persona IdAlumnoNavigation { get; set; }
        public virtual Persona IdProfesorNavigation { get; set; }
    }
}
