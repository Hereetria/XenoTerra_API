using XenoTerra.DTOLayer.Dtos.ReactionDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Types.Self.Own
{
    public class ReactionWithRelationsOwnType : ObjectType<ResultReactionWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReactionWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultReactionWithRelationsOwn");
        }
    }
}
