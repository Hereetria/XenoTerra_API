using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types.Admin
{
    public class BlockUserAdminType : ObjectType<ResultBlockUserAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultBlockUserAdminDto> descriptor)
        {
            descriptor.Name("ResultBlockUserAdmin");
        }
    }
}
