using XenoTerra.DTOLayer.Dtos.ReactionDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Types.Self.Own
{
    public class ReactionOwnType : ObjectType<ResultReactionOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReactionOwnDto> descriptor)
        {
            descriptor.Name("ResultReactionOwn");
        }
    }
}
