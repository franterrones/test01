using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.PaginationInterfaces;
using ie.nta.cabs.WCF.Common.Interfaces;
using DataTransferObjects;

namespace WCFConsultoras.Helpers
{
    public static class PaginationHelper
    {

        public static IPagination<T> AsPagination<T>(this IEnumerable<T> source, IPaginationRequest<T> request)
            where T : class, new()
        {
            var pageNumber = request.PageNumber ?? 1;

            var pageSize = 10000;//request.PageSize ?? 100;

            var secretKey = request.SecretKey;

            //TODO: next request
            return source.AsPagination<T>(string.Empty/*request.SortBy*/, false/*request.SortAscending*/, pageNumber, pageSize, secretKey );
           
        }

        public static IPagination<T> AsPagination<T>(this IEnumerable<T> source, string orderingByProperty, bool direction, int pageNumber, int pageSize, string secretKey)
            where T : class,  new()
        {
            if (pageNumber < 1)
               pageNumber = 1;
           
              return new DeferredPagination<T>(source.AsQueryable(), orderingByProperty, direction, pageNumber, pageSize, secretKey) as IPagination<T>;
          
        }

    }
}
