using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportStoryServices.Read
{
    public class ReportStoryReadService(IReadRepository<ReportStory, Guid> readRepository) : ReadService<ReportStory, Guid>(readRepository), IReportStoryReadService
    {
    }
}
