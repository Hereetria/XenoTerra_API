using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Types.Self.Public
{
    public class PostWithRelationsPublicType : ObjectType<ResultPostWithRelationsPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostWithRelationsPublicDto> descriptor)
        {
            descriptor.Name("ResultPostWithRelationsPublic");
        }
    }
}
