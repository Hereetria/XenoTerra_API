using XenoTerra.DTOLayer.Dtos.LikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Types
{
    public class LikeWithRelationsType : ObjectType<ResultLikeWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultLikeWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultLikeWithRelations");
        }
    }
}
