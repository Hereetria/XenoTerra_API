using XenoTerra.DTOLayer.Dtos.LikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Types
{
    public class LikeType : ObjectType<ResultLikeDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultLikeDto> descriptor)
        {
            descriptor.Name("ResultLike");
        }
    }
}
