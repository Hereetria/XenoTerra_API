using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.PostRepositories
{
    public interface IPostWriteRepository : IWriteRepository<Post, Guid>
    {
    }
}
