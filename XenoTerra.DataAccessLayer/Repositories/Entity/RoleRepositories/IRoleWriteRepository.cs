using Microsoft.AspNetCore.Identity;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.RoleRepository
{
    public interface IRoleWriteRepository
    {
        Task<IdentityRole<Guid>> InsertAsync(IdentityRole<Guid> role);
        Task<IdentityRole<Guid>> ModifyAsync(IdentityRole<Guid> role, IEnumerable<string> modifiedFields);
        Task<IdentityRole<Guid>> RemoveAsync(Guid id);
    }
}
