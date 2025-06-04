using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.UserQueryServices
{
    public interface IAppUserQueryService : IQueryService<AppUser, Guid>
    {
    }
}
