using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Types
{
    public class CommentType : ObjectType<ResultCommentDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentDto> descriptor)
        {
            descriptor.Name("ResultComment");
        }
    }
}
