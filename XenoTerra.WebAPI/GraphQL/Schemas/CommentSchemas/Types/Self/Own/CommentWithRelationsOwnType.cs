using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Types.Self.Own
{
    public class CommentWithRelationsOwnType : ObjectType<ResultCommentWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultCommentWithRelationsOwn");
        }
    }
}
