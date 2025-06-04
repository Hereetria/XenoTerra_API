using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.AppUserRepositories
{
    public interface IAppUserWriteRepository
    {
        Task<AppUser> InsertAsync(AppUser user, string password);
        Task<AppUser> ModifyAsync(AppUser user, IEnumerable<string> modifiedFields);
        Task<AppUser> RemoveAsync(Guid id);
    }
}
