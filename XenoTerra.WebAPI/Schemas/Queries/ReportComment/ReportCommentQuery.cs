using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.ReportCommentServices;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.ReportComment
{
    public class ReportCommentQuery
    {
        [UseProjection]
        [GraphQLDescription("Get all ReportComments")]
        public IQueryable<ResultReportCommentDto> GetAllReportComments([Service] IReportCommentServiceBLL reportCommentServiceBLL)
        {
            return reportCommentServiceBLL.GetAllQuerable();
        }

        [UseProjection]
        [GraphQLDescription("Get ReportComment by ID")]
        public IQueryable<ResultReportCommentByIdDto> GetReportCommentById(Guid id, [Service] IReportCommentServiceBLL reportCommentServiceBLL)
        {
            var result = reportCommentServiceBLL.GetByIdQuerable(id);
            if (result == null)
            {
                throw new Exception($"ReportComment with ID {id} not found");
            }
            return result;
        }
    }

}
