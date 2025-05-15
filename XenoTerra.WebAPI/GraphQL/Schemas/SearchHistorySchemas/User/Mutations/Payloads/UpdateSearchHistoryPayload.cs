using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Mutations.Payloads
{
    public record UpdateSearchHistoryPayload : Payload<ResultSearchHistoryDto>;
}
