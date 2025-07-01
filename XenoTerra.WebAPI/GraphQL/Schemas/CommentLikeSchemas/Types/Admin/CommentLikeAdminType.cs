using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Types.Admin
{
    public class CommentLikeAdminType : ObjectType<ResultCommentLikeAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentLikeAdminDto> descriptor)
        {
            descriptor.Name("ResultCommentLikeAdmin");
        }
    }
}
