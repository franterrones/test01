using System;
using System.Runtime.Serialization;
using DataTransferObjects.ConsultorasService;
using NameSpaces;

namespace Contracts.Requests
{
    [DataContract(Namespace = ConstNameSpaces.RequestRoot)]
    public class GetConsultorasRequest:ListRequest<Consultoras>
    {

    }
}
