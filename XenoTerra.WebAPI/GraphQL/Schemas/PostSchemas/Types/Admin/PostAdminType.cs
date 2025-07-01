using XenoTerra.DTOLayer.Dtos.PostDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Types.Admin
{
    public class PostAdminType : ObjectType<ResultPostAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostAdminDto> descriptor)
        {
            descriptor.Name("ResultPostAdmin");
        }
    }
}
