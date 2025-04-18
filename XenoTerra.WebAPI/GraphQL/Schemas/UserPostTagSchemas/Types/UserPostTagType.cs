using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Types
{
    public class UserPostTagType : ObjectType<ResultUserPostTagDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserPostTagDto> descriptor)
        {
            descriptor.Name("ResultUserPostTag");
        }
    }
}
