using System;
using System.Collections.Generic;

namespace ApiSchoolAdministrator.Core.Entities
{
    public partial class Persona
    {
        public int Id { get; set; }
        public long Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public short Edad { get; set; }
        public string Direccion { get; set; }
        public long Telefono { get; set; }
        public short Rol { get; set; }

        public Asignatura Asignatura { get; set; }
    }
}
