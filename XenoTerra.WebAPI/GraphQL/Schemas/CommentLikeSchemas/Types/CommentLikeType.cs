using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Types
{
    public class CommentLikeType : ObjectType<ResultCommentLikeDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentLikeDto> descriptor)
        {
            descriptor.Name("ResultCommentLike");
        }
    }
}
