using XenoTerra.DTOLayer.Dtos.ReactionDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Types.Admin
{
    public class ReactionWithRelationsAdminType : ObjectType<ResultReactionWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReactionWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultReactionWithRelationsAdmin");
        }
    }
}
