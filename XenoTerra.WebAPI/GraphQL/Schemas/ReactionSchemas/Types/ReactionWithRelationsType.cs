using XenoTerra.DTOLayer.Dtos.ReactionDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Types
{
    public class ReactionWithRelationsType : ObjectType<ResultReactionWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReactionWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultReactionWithRelations");
        }
    }
}
