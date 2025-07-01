using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Types.Self.Own
{
    public class ViewStoryOwnType : ObjectType<ResultViewStoryOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultViewStoryOwnDto> descriptor)
        {
            descriptor.Name("ResultViewStoryOwn");
        }
    }
}
