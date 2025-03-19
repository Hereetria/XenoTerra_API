using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.HighlightResolvers
{
    public interface IHighlightResolver : IEntityResolver<Highlight, ResultHighlightWithRelationsDto, Guid>
    {
    }
}
