using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Mutations.Payloads
{
    public record UpdateStoryHighlightPayload : Payload<ResultStoryHighlightDto>;
}
