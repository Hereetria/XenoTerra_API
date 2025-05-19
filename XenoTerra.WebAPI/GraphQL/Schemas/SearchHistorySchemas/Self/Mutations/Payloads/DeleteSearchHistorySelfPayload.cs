using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Mutations.Payloads
{
    public record DeleteSearchHistorySelfPayload : Payload<ResultSearchHistoryDto>;
}
