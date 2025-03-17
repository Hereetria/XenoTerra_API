using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.WebAPI.Schemas.DataLoaders.Entity;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.HighlightResolvers;

namespace XenoTerra.WebAPI.Schemas.Types
{
    public class ResultHighlightDtoType : ObjectType<ResultHighlightWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultHighlightWithRelationsDto> descriptor)
        {

        }
    }

}
