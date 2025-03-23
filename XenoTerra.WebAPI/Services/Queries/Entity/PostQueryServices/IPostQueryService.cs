using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.PostQueryServices
{
    public interface IPostQueryService : IQueryService<Post, Guid>
    {
    }

}
