using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations.Payloads
{
    public record DeleteSearchHistoryUserAdminPayload : Payload<ResultSearchHistoryUserAdminDto>;
}
