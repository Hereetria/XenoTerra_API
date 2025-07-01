using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Types.Admin
{
    public class CommentLikeWithRelationsAdminType : ObjectType<ResultCommentLikeWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentLikeWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultCommentLikeWithRelationsAdmin");
        }
    }
}
