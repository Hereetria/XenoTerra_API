using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.RoleService
{
    public class RoleWriteService(
            IWriteRepository<Role, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateRoleDto> createValidator,
            IValidator<UpdateRoleDto> updateValidator
        )
            : WriteService<Role, CreateRoleDto, UpdateRoleDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            IRoleWriteService
    {
    }
}
