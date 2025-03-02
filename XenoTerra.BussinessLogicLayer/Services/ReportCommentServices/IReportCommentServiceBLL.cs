
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.ReportCommentServices
{
        public interface IReportCommentServiceBLL : IGenericRepositoryBLL<ReportComment, ResultReportCommentDto, ResultReportCommentByIdDto, CreateReportCommentDto, UpdateReportCommentDto, Guid>
    {

    }
}