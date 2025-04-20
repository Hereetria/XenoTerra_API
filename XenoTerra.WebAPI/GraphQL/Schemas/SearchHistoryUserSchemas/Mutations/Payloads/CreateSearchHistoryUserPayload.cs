using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Mutations.Payloads
{
    public record CreateSearchHistoryUserPayload : Payload<ResultSearchHistoryUserDto>;
}
