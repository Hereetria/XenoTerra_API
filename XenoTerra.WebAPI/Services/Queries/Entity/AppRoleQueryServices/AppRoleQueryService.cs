using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.RoleQueryServices
{
    public class AppRoleQueryService : QueryService<AppRole, Guid>, IAppRoleQueryService
    {
        public AppRoleQueryService(IReadService<AppRole, Guid> readService)
            : base(readService)
        {
        }
    }
}
