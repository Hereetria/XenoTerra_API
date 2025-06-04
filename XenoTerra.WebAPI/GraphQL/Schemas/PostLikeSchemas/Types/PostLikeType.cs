using XenoTerra.DTOLayer.Dtos.PostLikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Types
{
    public class PostLikeType : ObjectType<ResultPostLikeDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostLikeDto> descriptor)
        {
            descriptor.Name("ResultPostLike");
        }
    }
}
