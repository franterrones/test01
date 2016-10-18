using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using NameSpaces;
using Common.DTO;

namespace DataTransferObjects.ConsultorasService
{
    [DataContract(Namespace = ConstNameSpaces.DTORoot)]
    public class Consultoras : BaseDTO, IConsultoras
    {
        [DataMember]
        public string nombrecompleto { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string region { get; set; }

        [DataMember]
        public string zona { get; set; }

        [DataMember]
        public string segmento { get; set; }

        [DataMember]
        public string seccion { get; set; }

        [DataMember]
        public bool esconsultoralider { get; set; }

        [DataMember]
        public string codigonivellider { get; set; }

        [DataMember]
        public string campaniainiciolider { get; set; }

        [DataMember]
        public string secciongestionlider { get; set; }

        [DataMember]
        public string nivelproyectado { get; set; }
    }
}
