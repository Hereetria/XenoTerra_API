using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Types.Self.Public
{
    public class CommentPublicType : ObjectType<ResultCommentPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentPublicDto> descriptor)
        {
            descriptor.Name("ResultCommentPublic");
        }
    }
}
