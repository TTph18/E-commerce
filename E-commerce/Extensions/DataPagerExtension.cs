using E_commerce.Shared;
using E_commerce.Shared.DTO;
using E_commerce.Shared.DTO.Paging;
using E_commerce.Shared.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;

namespace E_commerce.Extensions
{
    public static class DataPagerExtension
    {
        public static async Task<PagingModelDTO<T>> PaginateAsync<T>(
            this IQueryable<T> query,
            BaseQueryCriteriaDTO criteriaDto,
            CancellationToken cancellationToken)
            where T : class
        {

            var paged = new PagingModelDTO<T>();

            paged.CurrentPage = (criteriaDto.Page < 0) ? 1 : criteriaDto.Page;
            paged.PageSize = criteriaDto.Limit;

            if (!string.IsNullOrEmpty(criteriaDto.SortOrder.ToString()) &&
                !string.IsNullOrEmpty(criteriaDto.SortColumn))
            {
                var sortOrder = criteriaDto.SortOrder == SortOrderEnum.Accsending ?
                                    PagingSortingConstants.ASC :
                                    PagingSortingConstants.DESC;
                var orderString = $"{criteriaDto.SortColumn} {sortOrder}";
                query = query.OrderBy(orderString);
            }

            var startRow = (paged.CurrentPage - 1) * paged.PageSize;

            paged.Items = await query
                        .Skip(startRow)
                        .Take(paged.PageSize)
                        .ToListAsync(cancellationToken);

            paged.TotalItems = await query.CountAsync(cancellationToken);
            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)paged.PageSize);

            return paged;
        }
    }
}
