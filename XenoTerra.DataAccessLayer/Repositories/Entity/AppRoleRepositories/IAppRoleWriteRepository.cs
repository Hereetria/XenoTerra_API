using Microsoft.AspNetCore.Identity;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.AppRoleRepositories
{
    public interface IAppRoleWriteRepository
    {
        Task<AppRole> InsertAsync(AppRole role);
        Task<AppRole> ModifyAsync(AppRole role, IEnumerable<string> modifiedFields);
        Task<AppRole> RemoveAsync(Guid id);
    }
}
