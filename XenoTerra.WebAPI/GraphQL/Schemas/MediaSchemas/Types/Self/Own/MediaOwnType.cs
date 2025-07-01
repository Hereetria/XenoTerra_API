using XenoTerra.DTOLayer.Dtos.MediaDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Types.Self.Own
{
    public class MediaOwnType : ObjectType<ResultMediaOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultMediaOwnDto> descriptor)
        {
            descriptor.Name("ResultMediaOwn");
        }
    }
}
