using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.RoleServices;
using XenoTerra.DTOLayer.Dtos.RoleDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Role
{
    public class RoleQuery
    {
        public string GetRandomData()
        {
            return "Default data to prevent query class from being empty.";
        }

        //[UseProjection]
        //[GraphQLDescription("Get all Roles")]
        //public IQueryable<ResultRoleDto> GetAllRoles([Service] IRoleServiceBLL roleServiceBLL)
        //{
        //    return roleServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get Role by ID")]
        //public IQueryable<ResultRoleByIdDto> GetRoleById(Guid id, [Service] IRoleServiceBLL roleServiceBLL)
        //{
        //    var result = roleServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"Role with ID {id} not found");
        //    }
        //    return result;
        //}
    }
}
