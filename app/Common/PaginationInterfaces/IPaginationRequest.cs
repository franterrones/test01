using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.PaginationInterfaces
{
    public interface IPaginationRequest<TSource>
    {
        //String SortBy { get; set; }

        //Boolean SortAscending { get; set; }

        Int32? PageNumber { get; set; }

        //Int32? PageSize { get; set; }

        String SecretKey { get; set; }

     

    }
}
