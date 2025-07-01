using XenoTerra.DTOLayer.Dtos.CommentDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Types.Admin
{
    public class CommentAdminType : ObjectType<ResultCommentAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentAdminDto> descriptor)
        {
            descriptor.Name("ResultCommentAdmin");
        }
    }
}
