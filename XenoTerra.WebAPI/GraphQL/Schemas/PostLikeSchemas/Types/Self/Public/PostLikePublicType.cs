using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Types.Self.Public
{
    public class PostLikePublicType : ObjectType<ResultPostLikePublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostLikePublicDto> descriptor)
        {
            descriptor.Name("ResultPostLikePublic");
        }
    }
}
