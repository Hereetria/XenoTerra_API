using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Mutations.Payloads
{
    public record CreateReportCommentAdminPayload : Payload<ResultReportCommentAdminDto>;
}
