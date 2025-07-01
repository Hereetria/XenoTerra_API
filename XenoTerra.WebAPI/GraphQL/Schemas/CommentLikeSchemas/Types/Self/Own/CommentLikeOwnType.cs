using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.OwnTypes
{
    public class CommentLikeOwnType : ObjectType<ResultCommentLikeOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentLikeOwnDto> descriptor)
        {
            descriptor.Name("ResultCommentLikeOwn");
        }
    }
}
