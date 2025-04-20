using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.RoleMutationServices
{
    public interface IRoleMutationService : IMutationService<Role, ResultRoleDto, CreateRoleDto, UpdateRoleDto, Guid>
    {
    }
}
