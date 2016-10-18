using System.Runtime.Serialization;
using DataTransferObjects;
using NameSpaces;

namespace Contracts.Responses
{
    public interface IPaginationResponse<T>
    {
        Pagination<T> ResultList { get; set; }
    }

    [DataContract(Namespace = ConstNameSpaces.ResponseRoot)]
    public class ListResponse<T> : BaseResponse, IPaginationResponse<T>
        where T : class,  new()
    {

        [DataMember]
        public Pagination<T> ResultList { get; set; }
    }

   
}
