using HotChocolate.Data.Filters;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types.Admin
{
    public class BlockUserWithRelationsAdminType : ObjectType<ResultBlockUserWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultBlockUserWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultBlockUserWithRelationsAdmin");

        }
    }
}
