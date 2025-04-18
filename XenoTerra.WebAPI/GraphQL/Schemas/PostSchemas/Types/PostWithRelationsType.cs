using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Types
{
    public class PostWithRelationsType : ObjectType<ResultPostWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultPostWithRelations");
        }
    }
}
