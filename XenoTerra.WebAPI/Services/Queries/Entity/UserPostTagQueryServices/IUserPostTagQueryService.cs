using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.UserPostTagQueryServices
{
    public interface IUserPostTagQueryService : IQueryService<UserPostTag, ResultUserPostTagWithRelationsDto, Guid> { }

}
