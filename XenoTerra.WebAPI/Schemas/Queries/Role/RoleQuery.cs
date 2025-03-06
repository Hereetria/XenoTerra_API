using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.RoleServices;
using XenoTerra.DTOLayer.Dtos.RoleDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Role
{
    public class RoleQuery
    {
        [UseProjection]
        public IQueryable<ResultRoleWithRelationsDto> GetRoles(
        List<Guid>? ids,
        [Service] IRoleServiceBLL service
    ) => service.GetByIdsQuerableWithRelations(ids ?? service.GetAllIdsAsync().Result);

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
