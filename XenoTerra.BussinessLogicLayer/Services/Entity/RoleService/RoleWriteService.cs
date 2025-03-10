using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.RoleService
{
    public class RoleWriteService : WriteService<Role, ResultRoleDto, CreateRoleDto, UpdateRoleDto, Guid>, IRoleWriteService
    {
        public RoleWriteService(IWriteRepository<Role, Guid> repository, IMapper mapper, SelectorExpressionProvider<Role, ResultRoleDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }
}
