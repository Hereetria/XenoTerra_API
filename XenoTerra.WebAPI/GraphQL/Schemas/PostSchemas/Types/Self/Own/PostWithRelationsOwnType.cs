using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Types.Self.Own
{
    public class PostWithRelationsOwnType : ObjectType<ResultPostWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultPostWithRelationsOwn");
        }
    }
}
