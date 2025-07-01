using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Types.Self.Own
{
    public class ViewStoryWithRelationsOwnType : ObjectType<ResultViewStoryWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultViewStoryWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultViewStoryWithRelationsOwn");
        }
    }
}
