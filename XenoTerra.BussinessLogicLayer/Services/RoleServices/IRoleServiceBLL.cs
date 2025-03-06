
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.RoleServices
{
        public interface IRoleServiceBLL : IGenericRepositoryBLL<Role, ResultRoleDto, CreateRoleDto, UpdateRoleDto, Guid>
    {

    }
}