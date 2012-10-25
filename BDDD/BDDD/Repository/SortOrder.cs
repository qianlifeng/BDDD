using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Repository
{
    /// <summary>
    /// 查询时的排序方式
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// 不指定
        /// </summary>
        Unspecified = -1,
        /// <summary>
        /// 顺序
        /// </summary>
        Ascending = 0,
        /// <summary>
        /// 降序
        /// </summary>
        Descending = 1
    }
}
