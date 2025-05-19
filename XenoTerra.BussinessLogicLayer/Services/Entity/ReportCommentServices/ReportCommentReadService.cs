using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentServices
{
    public class ReportCommentReadService(IReadRepository<ReportComment, Guid> readRepository) : ReadService<ReportComment, Guid>(readRepository), IReportCommentReadService
    {
    }
}
