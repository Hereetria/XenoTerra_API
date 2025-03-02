
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.RoleServices
{
    
    public interface IRoleServiceDAL : IGenericRepositoryDAL<Role, ResultRoleDto, ResultRoleByIdDto ,CreateRoleDto, UpdateRoleDto, Guid>

    {

    }
}