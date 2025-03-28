using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.RoleQueryServices
{
    public class RoleQueryService : QueryService<Role, Guid>, IRoleQueryService
    {
        public RoleQueryService(IReadService<Role, Guid> readService)
            : base(readService)
        {
        }
    }
}
