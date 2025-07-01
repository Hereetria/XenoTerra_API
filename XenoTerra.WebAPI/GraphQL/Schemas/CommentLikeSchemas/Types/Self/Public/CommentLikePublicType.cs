using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Types.Self.Public
{
    public class CommentLikePublicType : ObjectType<ResultCommentLikePublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentLikePublicDto> descriptor)
        {
            descriptor.Name("ResultCommentLikePublic");
        }
    }
}
