using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Types.Self.Public
{
    public class PostPublicType : ObjectType<ResultPostPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostPublicDto> descriptor)
        {
            descriptor.Name("ResultPostPublic");
        }
    }
}
