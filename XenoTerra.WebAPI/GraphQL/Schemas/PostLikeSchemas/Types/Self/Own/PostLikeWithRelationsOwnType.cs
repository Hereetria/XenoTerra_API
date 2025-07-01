using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Types.Self.Own
{
    public class PostLikeWithRelationsOwnType : ObjectType<ResultPostLikeWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostLikeWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultPostLikeWithRelationsOwn");
        }
    }
}
