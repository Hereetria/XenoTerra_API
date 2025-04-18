using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Types
{
    public class CommentWithRelationsType : ObjectType<ResultCommentWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultCommentWithRelations");
        }
    }
}
