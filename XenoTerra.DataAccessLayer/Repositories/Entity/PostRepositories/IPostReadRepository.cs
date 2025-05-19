using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.PostRepositories
{
    public interface IPostReadRepository : IReadRepository<Post, Guid>
    {
    }
}
