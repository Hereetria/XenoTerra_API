using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentService;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.ReportCommentMutations
{
    public class ReportCommentMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new ReportComment")]
        public async Task<ResultReportCommentDto> CreateReportCommentAsync(CreateReportCommentDto createReportCommentDto, [Service] IReportCommentWriteService reportCommentWriteService)
        {
            var result = await reportCommentWriteService.CreateAsync(createReportCommentDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing ReportComment")]
        public async Task<ResultReportCommentDto> UpdateReportCommentAsync(UpdateReportCommentDto updateReportCommentDto, [Service] IReportCommentWriteService reportCommentWriteService)
        {
            var result = await reportCommentWriteService.UpdateAsync(updateReportCommentDto);
            return result;
        }

        [GraphQLDescription("Delete a ReportComment by ID")]
        public async Task<bool> DeleteReportCommentAsync(Guid id, [Service] IReportCommentWriteService reportCommentWriteService)
        {
            var result = await reportCommentWriteService.DeleteAsync(id);
            return result;
        }
    }
}
