using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Mutations.Payloads
{
    public record CreateReportCommentSelfPayload : Payload<ResultReportCommentDto>;
}
