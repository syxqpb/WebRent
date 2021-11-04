using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest2ebt.UI.Models
{
    public class PageInfo
    {
        /// <summary>
        /// Gets or sets current page number.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets objects count on page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets total items.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets total pages.
        /// </summary>
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}
