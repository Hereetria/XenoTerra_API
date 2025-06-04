using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.UserQueryServices
{
    public class AppUserQueryService : QueryService<AppUser, Guid>, IAppUserQueryService
    {
        public AppUserQueryService(IReadService<AppUser, Guid> readService)
            : base(readService)
        {
        }
    }
}
