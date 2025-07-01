using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Types.Self.Public
{
    public class UserPostTagWithRelationsPublicType : ObjectType<ResultUserPostTagWithRelationsPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserPostTagWithRelationsPublicDto> descriptor)
        {
            descriptor.Name("ResultUserPostTagWithRelationsPublic");
        }
    }
}
