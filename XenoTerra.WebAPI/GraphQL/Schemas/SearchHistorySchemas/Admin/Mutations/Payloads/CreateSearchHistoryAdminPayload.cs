using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Mutations.Payloads
{
    public record CreateSearchHistoryAdminPayload : Payload<ResultSearchHistoryAdminDto>;
}
