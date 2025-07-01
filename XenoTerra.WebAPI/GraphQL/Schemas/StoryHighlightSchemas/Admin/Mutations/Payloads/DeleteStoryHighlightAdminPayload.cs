using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Payloads
{
    public record DeleteStoryHighlightAdminPayload : Payload<ResultStoryHighlightAdminDto>;
}
