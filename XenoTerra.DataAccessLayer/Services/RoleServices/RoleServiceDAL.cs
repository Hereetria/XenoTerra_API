

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.RoleServices
{
    
    public class RoleServiceDAL : GenericRepositoryDAL<Role, ResultRoleDto, ResultRoleByIdDto, CreateRoleDto, UpdateRoleDto, Guid>, IRoleServiceDAL

    {

        public RoleServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}