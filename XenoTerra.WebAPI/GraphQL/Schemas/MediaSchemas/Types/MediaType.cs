using XenoTerra.DTOLayer.Dtos.MediaDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Types
{
    public class MediaType : ObjectType<ResultMediaDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultMediaDto> descriptor)
        {
            descriptor.Name("ResultMedia");
        }
    }
}
