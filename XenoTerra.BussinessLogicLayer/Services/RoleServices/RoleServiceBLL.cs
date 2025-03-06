
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.BussinessLogicLayer.Services.RoleServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.RoleServices
{
     public class RoleServiceBLL : GenericRepositoryBLL<Role, ResultRoleDto, CreateRoleDto, UpdateRoleDto, Guid>, IRoleServiceBLL
    {
        public RoleServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}