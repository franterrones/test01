using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ie.nta.cabs.WCF.Common.Interfaces
{
    /// <summary>
    /// The interface supports a collection of objects of pagination.
    /// </summary>
    /// <remarks>Used mostly in search results.</remarks>
    public interface IPagination : IEnumerable
    {
        /// <summary>
        /// Gets the current page number.
        /// </summary>
        /// <remarks></remarks>
       // Int32 PageNumber { get; }

        /// <summary>
        /// Gets the number of items per page.
        /// </summary>
        /// <remarks></remarks>
        //Int32 PageSize { get; }

        /// <summary>
        /// Gets the total number of elements.
        /// </summary>
        /// <remarks></remarks>
       // Int32 TotalItems { get; }

        /// <summary>
        ///Gets the total number of pages.
        /// </summary>
        /// <remarks></remarks>
        //Int32 TotalPages { get; }

        /// <summary>
        ///Gets the index of the first element on the page.
        /// </summary>
        /// <remarks></remarks>
       // Int32 FirstItem { get; }

        /// <summary>
        /// Gets the index of the last element on the page.
        /// </summary>
        /// <remarks></remarks>
       // Int32 LastItem { get; }

        /// <summary>
        /// Gets a value indicating whether an instance of the previous page.
        /// </summary>
        /// <remarks></remarks>
        //Boolean HasPreviousPage { get; }

        /// <summary>
        /// Gets a value indicating whether the instance has the next page.
        /// </summary>
        /// <remarks></remarks>
        Boolean HasNextPage { get; }

        /// <summary>
        /// Gets a value if the user is log in.
        /// </summary>
        /// <remarks></remarks>
        String Token { get; }

    }

    /// <summary>
    /// Generic for <see cref="IPagination"/>.
    /// </summary>
    /// <typeparam name="T">The type of object that is paging.</typeparam>
    /// <remarks></remarks>
    public interface IPagination<T> : IPagination, IEnumerable<T>
    {
    }
}
