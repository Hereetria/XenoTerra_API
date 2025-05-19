using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.UserRepositories
{
    public interface IUserWriteRepository
    {
        Task<User> InsertAsync(User user, string password);
        Task<User> ModifyAsync(User user, IEnumerable<string> modifiedFields);
        Task<User> RemoveAsync(Guid id);
    }
}
