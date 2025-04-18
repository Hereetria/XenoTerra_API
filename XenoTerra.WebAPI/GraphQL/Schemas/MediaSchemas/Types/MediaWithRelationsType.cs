using XenoTerra.DTOLayer.Dtos.MediaDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Types
{
    public class MediaWithRelationsType : ObjectType<ResultMediaWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultMediaWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultMediaWithRelations");
        }
    }
}
