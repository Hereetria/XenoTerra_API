using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Types.Self.Own
{
    public class PostLikeOwnType : ObjectType<ResultPostLikeOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostLikeOwnDto> descriptor)
        {
            descriptor.Name("ResultPostLikeOwn");
        }
    }
}
