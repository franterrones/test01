using System;
using System.Runtime.Serialization;
using Common.PaginationInterfaces;
using NameSpaces;

namespace Contracts.Requests
{
    [DataContract(Namespace = ConstNameSpaces.RequestRoot)]
    public class ListRequestConsultora<T> : BaseRequest, IPaginationRequest<T>
    {
        //[DataMember]
        //public String SortBy { get; set; }

        //[DataMember]
        //public Boolean SortAscending { get; set; }

        [DataMember]
        public Int32? PageNumber { get; set; }

        // [DataMember]
        //public Int32? PageSize { get; set; }

        [DataMember]
        public String SecretKey { get; set; }

        [DataMember]
        public String Pais { get; set; }

        [DataMember]
        public String CodConsultora { get; set; }


    }
}
