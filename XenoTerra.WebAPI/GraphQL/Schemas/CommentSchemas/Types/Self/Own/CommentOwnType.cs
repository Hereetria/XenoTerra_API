using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Types.Self.Own
{
    public class CommentOwnType : ObjectType<ResultCommentOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentOwnDto> descriptor)
        {
            descriptor.Name("ResultCommentOwn");
        }
    }
}
