using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD
{
    /// <summary>
    /// Represents the sorting style.
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// Indicates that the sorting style is not specified.
        /// </summary>
        Unspecified = -1,
        /// <summary>
        /// Indicates an ascending sorting.
        /// </summary>
        Ascending = 0,
        /// <summary>
        /// Indicates a descending sorting.
        /// </summary>
        Descending = 1
    }
}
