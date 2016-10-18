using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ie.nta.cabs.WCF.Common.Interfaces;
using System.Runtime.Serialization;
using System.Collections;
using NameSpaces;

namespace DataTransferObjects
{
    [DataContract(Namespace = ConstNameSpaces.DTORoot)]
    public class Pagination<T> : IPagination<T>
    {
        [DataMember]
        private readonly IList<T> _dataSource;

        public Pagination() { }

        public Pagination(IPagination<T> source)
        {
            _dataSource = source.ToList();

            //PageNumber = source.PageNumber;
            //PageSize = source.PageSize;
            //TotalItems = source.TotalItems;
            //TotalPages = source.TotalPages;
            //FirstItem = source.FirstItem;
            //LastItem = source.LastItem;
            //HasPreviousPage = source.HasPreviousPage;
            HasNextPage = source.HasNextPage;
            Token = source.Token;
           
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _dataSource.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //[DataMember]
        //public int PageNumber { get; set; }

        //[DataMember]
       // public int PageSize { get; set; }

       // [DataMember]
        //public int TotalItems { get; set; }

       // [DataMember]
       // public int TotalPages { get; set; }

        //[DataMember]
        //public int FirstItem { get; set; }

       // [DataMember]
       // public int LastItem { get; set; }

        //[DataMember]
        //public bool HasPreviousPage { get; set; }

        [DataMember]
        public bool HasNextPage { get; set; }

        [DataMember]
        public string Token { get; set; }
       
    }
}
