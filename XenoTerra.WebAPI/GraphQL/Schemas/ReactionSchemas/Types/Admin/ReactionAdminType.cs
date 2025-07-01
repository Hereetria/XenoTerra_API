using XenoTerra.DTOLayer.Dtos.ReactionDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Types.Admin
{
    public class ReactionAdminType : ObjectType<ResultReactionAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReactionAdminDto> descriptor)
        {
            descriptor.Name("ResultReactionAdmin");
        }
    }
}
