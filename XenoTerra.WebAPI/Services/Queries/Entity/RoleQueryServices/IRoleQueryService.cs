using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.RoleQueryServices
{
    public interface IRoleQueryService : IQueryService<Role, Guid>
    {
    }
}
