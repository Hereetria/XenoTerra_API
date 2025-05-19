using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Payloads
{
    public record DeleteStorySelfPayload : Payload<ResultStoryDto>;
}
