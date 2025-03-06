using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.ReportCommentServices;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.ReportComment
{
    public class ReportCommentMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new ReportComment")]
        public async Task<ResultReportCommentDto> CreateReportCommentAsync(CreateReportCommentDto createReportCommentDto, [Service] IReportCommentServiceBLL reportCommentServiceBLL)
        {
            var result = await reportCommentServiceBLL.CreateAsync(createReportCommentDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing ReportComment")]
        public async Task<ResultReportCommentDto> UpdateReportCommentAsync(UpdateReportCommentDto updateReportCommentDto, [Service] IReportCommentServiceBLL reportCommentServiceBLL)
        {
            var result = await reportCommentServiceBLL.UpdateAsync(updateReportCommentDto);
            return result;
        }

        [GraphQLDescription("Delete a ReportComment by ID")]
        public async Task<bool> DeleteReportCommentAsync(Guid id, [Service] IReportCommentServiceBLL reportCommentServiceBLL)
        {
            var result = await reportCommentServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
