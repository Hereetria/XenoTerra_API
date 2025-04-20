using AutoMapper;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.RoleMutationServices
{
    public class RoleMutationService(IMapper mapper)
        : MutationService<Role, ResultRoleDto, CreateRoleDto, UpdateRoleDto, Guid>(mapper),
        IRoleMutationService
    {
    }
}
