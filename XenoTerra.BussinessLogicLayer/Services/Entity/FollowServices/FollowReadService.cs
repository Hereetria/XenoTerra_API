using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.FollowServices
{
    public class FollowReadService(IReadRepository<Follow, Guid> readRepository) : ReadService<Follow, Guid>(readRepository), IFollowReadService
    {
    }
}
