using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiSchoolAdministrator.Core.Entities
{
    public partial class AlumnoAsignatura
    {
        [Key]
        public int IdAlumno { get; set; }
        [Key]
        public int IdProfesor { get; set; }
        public int Anio { get; set; }
        public string CodigoAsignatura { get; set; }
        public float Calificacion { get; set; }

        public virtual Persona IdAlumnoNavigation { get; set; }
        public virtual Persona IdProfesorNavigation { get; set; }
    }
}
