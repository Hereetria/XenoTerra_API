using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Mutations.Payloads
{
    public record CreateReportCommentPayload : Payload<ResultReportCommentDto>;
}
