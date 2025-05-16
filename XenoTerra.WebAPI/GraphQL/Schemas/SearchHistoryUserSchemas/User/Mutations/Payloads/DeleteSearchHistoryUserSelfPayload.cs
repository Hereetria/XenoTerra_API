using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations.Payloads
{
    public record DeleteSearchHistoryUserSelfPayload : Payload<ResultSearchHistoryUserDto>;
}
