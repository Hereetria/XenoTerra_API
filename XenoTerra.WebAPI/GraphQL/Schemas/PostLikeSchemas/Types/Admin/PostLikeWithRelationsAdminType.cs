using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Types.Admin
{
    public class PostLikeWithRelationsAdminType : ObjectType<ResultPostLikeWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostLikeWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultPostLikeWithRelationsAdmin");
        }
    }
}
