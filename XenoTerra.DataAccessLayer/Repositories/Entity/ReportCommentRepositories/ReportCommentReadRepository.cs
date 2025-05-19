using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.ReportCommentRepositories
{
    public class ReportCommentReadRepository(AppDbContext context) : ReadRepository<ReportComment, Guid>(context), IReportCommentReadRepository
    {
    }
}
