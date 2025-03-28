using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.RoleRepository
{
    public interface IRoleReadRepository : IReadRepository<Role, Guid>
    {
    }
}
