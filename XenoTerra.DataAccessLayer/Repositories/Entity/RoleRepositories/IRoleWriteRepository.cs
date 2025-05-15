using Microsoft.AspNetCore.Identity;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.RoleRepository
{
    public interface IRoleWriteRepository
    {
        Task<Role> InsertAsync(Role role);
        Task<Role> ModifyAsync(Role role, IEnumerable<string> modifiedFields);
        Task<Role> RemoveAsync(Guid id);
    }
}
