using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSchoolAdministrator.Core.Entities
{
    public class Response
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public object Payload { get; set; }
    }
}
