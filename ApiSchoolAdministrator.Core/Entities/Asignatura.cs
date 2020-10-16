using System;
using System.Collections.Generic;

namespace ApiSchoolAdministrator.Core
{
    public partial class Asignatura
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int? IdProfesor { get; set; }
    }
}
