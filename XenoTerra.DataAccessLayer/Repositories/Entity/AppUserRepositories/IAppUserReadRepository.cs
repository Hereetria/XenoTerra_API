using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.AppUserRepositories
{
    public interface IAppUserReadRepository : IReadRepository<AppUser, Guid>
    {
    }
}
