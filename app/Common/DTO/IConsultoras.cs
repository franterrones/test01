using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.DTO
{
    public interface IConsultoras
    {
         
         string nombrecompleto { get; set; }
         string email { get; set; }
         string region { get; set; }
         string zona { get; set; }
         string segmento { get; set; }
         string seccion { get; set; }
         bool esconsultoralider { get; set; }
         string codigonivellider { get; set; }
         string campaniainiciolider { get; set; }
         string secciongestionlider { get; set; }
         string nivelproyectado { get; set; }
    }
}
