using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.ReactionQueryServices
{
    public interface IReactionQueryService : IQueryService<Reaction, ResultReactionWithRelationsDto, Guid>
    {
    }
}
