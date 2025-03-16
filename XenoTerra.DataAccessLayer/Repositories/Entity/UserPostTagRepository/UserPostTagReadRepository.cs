using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.UserPostTagRepository
{
    public class UserPostTagReadRepository : ReadRepository<UserPostTag, Guid>, IUserPostTagReadRepository
    {
        public UserPostTagReadRepository(AppDbContext context) : base(context) { }

        public IQueryable<Post> GetPostByUserIdQueryable(Guid key)
        {
            if (key == Guid.Empty)
                throw new ArgumentException("Key cannot be empty.", nameof(key));

            return _context.UserPostTags
                .AsNoTracking()
                .Where(upt => upt.UserId == key)
                .Select(upt => upt.Post)
                .Distinct();
        }

        public IQueryable<Post> GetPostsByUserIdsQueryable(IEnumerable<Guid> keys)
        {
            if (keys is null || !keys.Any())
                throw new ArgumentException("At least one ID must be provided.", nameof(keys));

            var keySet = new HashSet<Guid>(keys);

            return _context.UserPostTags
                .AsNoTracking()
                .Where(upt => keySet.Contains(upt.UserId))
                .Select(upt => upt.Post)
                .Distinct();
        }

        public IQueryable<User> GetUserByPostId(Guid key)
        {
            if (key == Guid.Empty)
                throw new ArgumentException("Key cannot be empty.", nameof(key));

            return _context.UserPostTags
                .AsNoTracking()
                .Where(upt => upt.PostId == key)
                .Select(upt => upt.User)
                .Distinct();
        }

        public IQueryable<User> GetUsersByPostIdsQueryable(IEnumerable<Guid> keys)
        {
            if (keys is null || !keys.Any())
                throw new ArgumentException("At least one ID must be provided.", nameof(keys));

            var keySet = new HashSet<Guid>(keys);

            return _context.UserPostTags
                .AsNoTracking()
                .Where(upt => keySet.Contains(upt.PostId))
                .Select(upt => upt.User)
                .Distinct();
        }
    }
}
