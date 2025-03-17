using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.LikeQueryServices
{
    public interface ILikeQueryService : IBaseQueryService<Like, ResultLikeDto, Guid> { }

}
