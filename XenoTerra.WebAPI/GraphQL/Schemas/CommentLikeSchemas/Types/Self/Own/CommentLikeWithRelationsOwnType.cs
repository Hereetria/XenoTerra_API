using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Types.Self.Own
{
    public class CommentLikeWithRelationsOwnType : ObjectType<ResultCommentLikeWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentLikeWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultCommentLikeWithRelationsOwn");
        }
    }
}
