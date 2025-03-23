using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.FollowService
{
    public class FollowReadService : ReadService<Follow, Guid>, IFollowReadService
    {
        public FollowReadService(IReadRepository<Follow, Guid> repository)
            : base(repository) { }
    }
}
