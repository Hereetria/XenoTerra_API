using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.UserRepository
{
    public interface IUserWriteRepository : IWriteRepository<User, Guid>
    {
    }
}
