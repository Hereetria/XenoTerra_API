using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.RoleService
{
    public class RoleReadService : ReadService<Role, ResultRoleWithRelationsDto, Guid>, IRoleReadService
    {
        public RoleReadService(IReadRepository<Role, ResultRoleWithRelationsDto, Guid> repository, IMapper mapper)
            : base(repository) { }
    }
}
