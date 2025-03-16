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
    public interface IUserPostTagReadRepository : IReadRepository<UserPostTag, Guid> 
    {
        public IQueryable<Post> GetPostsByUserIdsQueryable(IEnumerable<Guid> keys);
        public IQueryable<Post> GetPostByUserIdQueryable(Guid key);
        public IQueryable<User> GetUsersByPostIdsQueryable(IEnumerable<Guid> keys);
        public IQueryable<User> GetUserByPostId(Guid key);
    }
}
