using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Mutations.Payloads
{
    public record UpdateStoryPayload : Payload<ResultStoryDto>;
}
