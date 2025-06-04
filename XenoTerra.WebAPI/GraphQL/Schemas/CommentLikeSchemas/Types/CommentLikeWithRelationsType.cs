using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Types
{
    public class CommentLikeWithRelationsType : ObjectType<ResultCommentLikeWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentLikeWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultCommentLikeWithRelations");
        }
    }
}
