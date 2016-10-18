using System.Runtime.Serialization;
using DataTransferObjects;
using NameSpaces;

namespace Contracts.Responses
{

    [DataContract(Namespace = ConstNameSpaces.ResponseRoot)]
    public class ListResponseConsultora<T> : BaseResponse, IPaginationResponse<T>
        where T : class, new()
    {

        [DataMember]
        public Pagination<T> ResultList { get; set; }
    }


}
