using XenoTerra.DTOLayer.Dtos.CommentDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Types.Admin
{
    public class CommentWithRelationsAdminType : ObjectType<ResultCommentWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultCommentWithRelationsAdmin");
        }
    }
}
