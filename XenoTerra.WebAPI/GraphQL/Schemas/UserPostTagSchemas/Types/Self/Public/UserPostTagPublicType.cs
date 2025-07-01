using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Types.Self.Public
{
    public class UserPostTagPublicType : ObjectType<ResultUserPostTagPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserPostTagPublicDto> descriptor)
        {
            descriptor.Name("ResultUserPostTagPublic");
        }
    }
}
