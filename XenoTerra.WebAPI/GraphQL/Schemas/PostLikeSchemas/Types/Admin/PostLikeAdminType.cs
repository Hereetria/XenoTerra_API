using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Types.Admin
{
    public class PostLikeAdminType : ObjectType<ResultPostLikeAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostLikeAdminDto> descriptor)
        {
            descriptor.Name("ResultPostLikeAdmin");
        }
    }
}
