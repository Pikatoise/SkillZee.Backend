using Microsoft.EntityFrameworkCore;
using SkillZee.Domain;
using SkillZee.Domain.Entities;
using SkillZee.Domain.Enum;
using SkillZee.Domain.Filters;
using SkillZee.Domain.Result;
using System.Linq.Expressions;

namespace SkillZee.Infrastructure.DAL.EntityExtensions
{
    public static class OrderExtensions
    {
        public static IQueryable<Order> Filter(this IQueryable<Order> query, OrderFilter filters)
        {
            if (!string.IsNullOrEmpty(filters.Title))
                query = query.Where(x => x.Title.Contains(filters.Title));

            if (filters.RewardMin != null)
                query = query.Where(x => x.Reward >= filters.RewardMin);

            if (filters.RewardMax != null)
                query = query.Where(x => x.Reward <= filters.RewardMax);

            if (filters.OrderSpeedId != null)
                query = query.Where(x => x.OrderSpeedId == filters.OrderSpeedId);

            if (filters.AreaId != null)
                query = query.Where(x => x.AreaId == filters.AreaId);

            return query;
        }

        public static async Task<PagedResult<Order>> Page(this IQueryable<Order> query, PageParams pageParams)
        {
            int count = await query.CountAsync();

            if (count == 0)
                return new PagedResult<Order>([], 0);

            int page = pageParams.Page ?? 1;
            int pageSize = pageParams.PageSize ?? 5;

            int skip = (page - 1) * pageSize;

            var result = await query.Skip(skip).Take(pageSize).ToArrayAsync();

            return new(result, count);
        }

        public static IQueryable<Order> Sort(this IQueryable<Order> query, SortParams sort)
        {
            if (string.IsNullOrEmpty(sort.OrderBy) || sort.SortDirection == null)
                return query.OrderByDescending(x => x.CreatedAt);

            return sort.SortDirection == SortDirection.Descending ?
                query.OrderByDescending(GetKeySelector(sort.OrderBy)) :
                query.OrderBy(GetKeySelector(sort.OrderBy));
        }

        private static Expression<Func<Order, object>> GetKeySelector(string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
                return x => x.CreatedAt;

            return orderBy switch
            {
                nameof(Order.CreatedAt) => x => x.CreatedAt,
                nameof(Order.Responses.Count) => x => x.Responses.Count,
                nameof(Order.Reward) => x => x.Reward,
                nameof(Order.Title) => x => x.Title,

                _ => x => x.CreatedAt
            };
        }
    }
}
