using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Types.Self.Public
{
    public class CommentWithRelationsPublicType : ObjectType<ResultCommentWithRelationsPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentWithRelationsPublicDto> descriptor)
        {
            descriptor.Name("ResultCommentWithRelationsPublic");
        }
    }
}
