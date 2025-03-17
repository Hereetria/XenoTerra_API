using XenoTerra.DTOLayer.Dtos.PostTagDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.UserPostTagQueryServices
{
    public interface IUserPostTagQueryService : IBaseQueryService<UserPostTag, ResultUserPostTagDto, Guid> { }

}
