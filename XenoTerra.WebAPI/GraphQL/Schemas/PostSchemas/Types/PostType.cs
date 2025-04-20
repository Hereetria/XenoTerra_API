using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Types
{
    public class PostType : ObjectType<ResultPostDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostDto> descriptor)
        {
            descriptor.Name("ResultPost");
        }
    }
}
