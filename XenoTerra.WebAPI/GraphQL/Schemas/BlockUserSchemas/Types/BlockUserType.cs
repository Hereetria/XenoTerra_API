using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types
{
    public class BlockUserType : ObjectType<ResultBlockUserDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultBlockUserDto> descriptor)
        {
            descriptor.Name("ResultBlockUser");
        }
    }
}
