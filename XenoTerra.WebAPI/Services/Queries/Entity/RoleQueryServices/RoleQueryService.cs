using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.RoleQueryServices
{
    public class RoleQueryService : QueryService<Role, Guid>, IRoleQueryService
    {
        public RoleQueryService(IReadService<Role, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }
}
