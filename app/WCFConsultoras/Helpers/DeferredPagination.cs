using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ie.nta.cabs.WCF.Common.Interfaces;
using System.Collections;

namespace WCFConsultoras.Helpers
{

    public class DeferredPagination<T> : IPagination<T>
            where T : class,  new()
    {
        #region Privates
        private IQueryable<T> _results;
        private Int32 _totalItems;
        #endregion

        #region Public properties
        public Int32 PageSize { get; private set; }

        public Int32 PageNumber { get; private set; }

        public string SecretKey { get;  set; }
     
        public IQueryable<T> Query { get; protected set; }

        public string SortBy { get; set; }

        public bool SortAscending { get; set; }

        public string SortExpression
        {
            get
            {
                return this.SortAscending ? this.SortBy + " asc" : this.SortBy + " desc";
            }
        }

        public Int32 TotalItems
        {
            get
            {
                TryExecuteQuery();
                return _totalItems;
            }
        }

        public Int32 TotalPages
        {
            get
            {
                int result = (Int32)Math.Ceiling(((double)TotalItems) / PageSize);
                return result == 0 ? 1 : result;
            }
        }

        public Int32 FirstItem
        {
            get
            {
                TryExecuteQuery();
                return ((PageNumber - 1) * PageSize) + 1;
            }
        }

        public Int32 LastItem
        {
            get
            {
                return FirstItem + _results.Count() - 1;
            }
        }

        public bool HasPreviousPage
        {
            get { return PageNumber > 1; }
        }

        public bool HasNextPage
        {
            get { return PageNumber < TotalPages; }
        }

        public string Token
        {
           get {

               string Token;

                if(SecretKey!=null)
                {
                    byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                    byte[] key = Guid.NewGuid().ToByteArray();
                    Token = Convert.ToBase64String(time.Concat(key).ToArray());
                }
               else{ Token = null;}
              
               return Token;
            }
        }
       
        #endregion

        #region Ctors
        public DeferredPagination(IQueryable<T> query, String orderingByProperty, bool direction, Int32 pageNumber, Int32 pageSize, String secretkey)
        {
            //SortBy = orderingByProperty;
            //SortAscending = direction;
          
            SecretKey = secretkey;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Query = query;
        }
        #endregion

        #region Functions
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            TryExecuteQuery();

            foreach (var item in _results)
            {
                yield return item;
            }
        }

        protected void TryExecuteQuery()
        {
            if (_results != null)
                return;

            _totalItems = Query.Count();
            _results = (IQueryable<T>)ExecuteQuery();
        }

        protected virtual IQueryable ExecuteQuery()
        {
            Int32 numberToSkip = (PageNumber - 1) * PageSize;
            while (numberToSkip > _totalItems)
            {
                numberToSkip -= PageSize;
                PageNumber--;
            }
            IQueryable results;
            //TODO: 
            //if (SortExpression.Length > 5)//Sort expression do not has property name
            //    results = Query.OrderBy(SortExpression).Skip(numberToSkip).Take(PageSize);
            //else
            results = Query.Skip(numberToSkip).Take(PageSize);

            return results;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
        #endregion


       
    }
}