using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types.Self.Own
{
    public class BlockUserOwnType : ObjectType<ResultBlockUserOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultBlockUserOwnDto> descriptor)
        {
            descriptor.Name("ResultBlockUserOwn");
        }
    }
}
