
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.BussinessLogicLayer.Services.ReportCommentServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.ReportCommentServices
{
     public class ReportCommentServiceBLL : GenericRepositoryBLL<ReportComment, ResultReportCommentDto, ResultReportCommentByIdDto, CreateReportCommentDto, UpdateReportCommentDto, Guid>, IReportCommentServiceBLL
    {
        public ReportCommentServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}