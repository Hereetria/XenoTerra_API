using XenoTerra.DTOLayer.Dtos.PostLikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Types
{
    public class PostLikeWithRelationsType : ObjectType<ResultPostLikeWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostLikeWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultPostLikeWithRelations");
        }
    }
}
