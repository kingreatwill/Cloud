using Abp.Application.Services.Dto;
using Abp.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Cloud.Blog.Extensions
{
    /// <summary>
    /// QueryableExtensions (PagedAndSortedResultRequestDto)
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// pageIndex=0
        /// </summary>
        public static PagedResultDto<T> PageListBy<T>(this IQueryable<T> query, int pageIndex, int pageSize, string sorting)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }
            if (!sorting.IsNullOrWhiteSpace())
            {
                query = query.OrderBy(sorting);
            }

            var totalCount = query.Count();

            query = query.Skip(pageIndex * pageSize).Take(pageSize);

            return new PagedResultDto<T>(
                totalCount,
                query.ToList()
            );
        }

        /// <summary>
        /// Used for paging with an <see cref="IPagedResultRequest"/> object.
        /// </summary>
        /// <param name="query">Queryable to apply paging</param>
        /// <param name="pagedResultRequest">An object implements <see cref="IPagedResultRequest"/> interface</param>
        public static PagedResultDto<T> PageListBy<T>(this IQueryable<T> query, PagedResultInput input)
        {
            return query.PageListBy(input.PageIndex, input.PageSize, input.Sorting);
        }
    }

    [Serializable]
    public class PagedResultInput
    {
        [Range(0, int.MaxValue)]
        public int PageIndex { get; set; }

        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }

        public string Sorting { get; set; }
    }
}