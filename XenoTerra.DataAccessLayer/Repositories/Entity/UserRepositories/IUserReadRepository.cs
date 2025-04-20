using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.UserRepository
{
    public interface IUserReadRepository : IReadRepository<User, Guid>
    {
    }
}
