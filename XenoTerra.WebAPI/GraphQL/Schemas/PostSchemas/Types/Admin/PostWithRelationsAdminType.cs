using XenoTerra.DTOLayer.Dtos.PostDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Types.Admin
{
    public class PostWithRelationsAdminType : ObjectType<ResultPostWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultPostWithRelationsAdmin");
        }
    }
}
