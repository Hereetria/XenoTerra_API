using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Types
{
    public class ViewStoryWithRelationsType : ObjectType<ResultViewStoryWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultViewStoryWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultViewStoryWithRelations");
        }
    }
}
