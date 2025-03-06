

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.ReportCommentServices
{
    
    public class ReportCommentServiceDAL : GenericRepositoryDAL<ReportComment, ResultReportCommentDto, ResultReportCommentWithRelationsDto, CreateReportCommentDto, UpdateReportCommentDto, Guid>, IReportCommentServiceDAL

    {

        public ReportCommentServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}