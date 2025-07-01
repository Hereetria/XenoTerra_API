using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Types.Self.Public
{
    public class CommentLikeWithRelationsPublicType : ObjectType<ResultCommentLikeWithRelationsPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentLikeWithRelationsPublicDto> descriptor)
        {
            descriptor.Name("ResultCommentLikeWithRelationsPublic");
        }
    }
}
