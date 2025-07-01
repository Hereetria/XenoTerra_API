using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Types.Self.Public
{
    public class PostLikeWithRelationsPublicType : ObjectType<ResultPostLikeWithRelationsPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostLikeWithRelationsPublicDto> descriptor)
        {
            descriptor.Name("ResultPostLikeWithRelationsPublic");
        }
    }
}
