using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.DTO;
using System.Runtime.Serialization;
using NameSpaces;

namespace DataTransferObjects
{
    [DataContract(Namespace = ConstNameSpaces.DTORoot)]
    public class BaseDTO : IBaseDTO
    {
        [DataMember]
        public string isocodconsultora { get; set; }
    }
}
