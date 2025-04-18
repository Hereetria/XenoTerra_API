using XenoTerra.DTOLayer.Dtos.ReactionDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Types
{
    public class ReactionType : ObjectType<ResultReactionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReactionDto> descriptor)
        {
            descriptor.Name("ResultReaction");
        }
    }
}
