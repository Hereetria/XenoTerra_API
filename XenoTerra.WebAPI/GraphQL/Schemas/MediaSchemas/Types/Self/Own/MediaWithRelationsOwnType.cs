using XenoTerra.DTOLayer.Dtos.MediaDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Types.Self.Own
{
    public class MediaWithRelationsOwnType : ObjectType<ResultMediaWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultMediaWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultMediaWithRelationsOwn");
        }
    }
}
