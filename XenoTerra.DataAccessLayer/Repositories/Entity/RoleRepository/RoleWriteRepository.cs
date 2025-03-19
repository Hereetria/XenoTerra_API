using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.RoleRepository
{
    public class RoleWriteRepository : WriteRepository<Role, ResultRoleDto, Guid>, IRoleWriteRepository
    {
        public RoleWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}
