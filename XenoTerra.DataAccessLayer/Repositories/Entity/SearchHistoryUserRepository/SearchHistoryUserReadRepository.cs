using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.SearchHistoryUserRepository
{
    public class SearchHistoryUserReadRepository : ReadRepository<SearchHistoryUser, Guid>, ISearchHistoryUserReadRepository
    {
        public SearchHistoryUserReadRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<SearchHistory> GetSearchHistoryByUserIdQueryable(Guid key)
        {
            if (key == Guid.Empty)
                throw new ArgumentException("Key cannot be empty.", nameof(key));

            return _context.SearchHistoryUsers
                .AsNoTracking()
                .Where(shu => shu.UserId == key)
                .Select(shu => shu.SearchHistory)
                .Distinct();
        }

        public IQueryable<SearchHistory> GetSearchHistoriesByUserIdsQueryable(IEnumerable<Guid> keys)
        {
            if (keys is null || !keys.Any())
                throw new ArgumentException("At least one ID must be provided.", nameof(keys));

            var keySet = new HashSet<Guid>(keys);

            return _context.SearchHistoryUsers
                .AsNoTracking()
                .Where(shu => keySet.Contains(shu.UserId))
                .Select(shu => shu.SearchHistory)
                .Distinct();
        }

        public IQueryable<User> GetUserBySearchHistoryIdQueryable(Guid key)
        {
            if (key == Guid.Empty)
                throw new ArgumentException("Key cannot be empty.", nameof(key));

            return _context.SearchHistoryUsers
                .AsNoTracking()
                .Where(shu => shu.SearchHistoryId == key)
                .Select(shu => shu.User)
                .Distinct();
        }

        public IQueryable<User> GetUsersBySearchHistoryIdsQueryable(IEnumerable<Guid> keys)
        {
            if (keys is null || !keys.Any())
                throw new ArgumentException("At least one ID must be provided.", nameof(keys));

            var keySet = new HashSet<Guid>(keys);

            return _context.SearchHistoryUsers
                .AsNoTracking()
                .Where(shu => keySet.Contains(shu.SearchHistoryId))
                .Select(shu => shu.User)
                .Distinct();
        }
    }
}
