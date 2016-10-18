using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Common.PaginationInterfaces;
using DataTransferObjects.ConsultorasService;

namespace Contracts.Responses
{
    [DataContract]
    public class GetConsultorasResponse : ListResponse<Consultoras>
    {

    }
}
