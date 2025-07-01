using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Types.Self.Own
{
    public class UserPostTagWithRelationsOwnType : ObjectType<ResultUserPostTagWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserPostTagWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultUserPostTagWithRelationsOwn");
        }
    }
}
