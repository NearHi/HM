using System;
using System.Collections.Generic;

namespace HMQuota.Utils
{
    /// <summary>
    /// 分页实体接口
    /// </summary>
    /// <typeparam name="T">实体</typeparam>
    public interface IPage<T>
    {
        /// <summary>
        /// 当前页
        /// </summary>
        int PageIndex { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        int TotalPages { get; set; }
        /// <summary>
        /// 查询集合总个数
        /// </summary>
        int TotalItems { get; set; }
        /// <summary>
        /// 每页项数
        /// </summary>
        int PageSize { get; set; }
        /// <summary>
        /// 查询集合
        /// </summary>
        IList<T> Items { get; set; }
    }
    
}