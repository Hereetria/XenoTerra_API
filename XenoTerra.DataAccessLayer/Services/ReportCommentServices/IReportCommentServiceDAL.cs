
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.ReportCommentServices
{
    
    public interface IReportCommentServiceDAL : IGenericRepositoryDAL<ReportComment, ResultReportCommentDto, ResultReportCommentByIdDto ,CreateReportCommentDto, UpdateReportCommentDto, Guid>

    {

    }
}