

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.RoleServices
{
    
    public class RoleServiceDAL : GenericRepositoryDAL<Role, ResultRoleDto, ResultRoleWithRelationsDto, CreateRoleDto, UpdateRoleDto, Guid>, IRoleServiceDAL

    {

        public RoleServiceDAL(AppDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}