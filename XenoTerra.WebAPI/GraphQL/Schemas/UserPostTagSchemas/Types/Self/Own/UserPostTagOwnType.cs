using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Types.Self.Own
{
    public class UserPostTagOwnType : ObjectType<ResultUserPostTagOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserPostTagOwnDto> descriptor)
        {
            descriptor.Name("ResultUserPostTagOwn");
        }
    }
}
