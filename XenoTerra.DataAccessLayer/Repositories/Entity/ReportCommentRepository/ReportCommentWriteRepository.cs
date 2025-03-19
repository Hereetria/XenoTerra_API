using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.ReportCommentRepository
{
    public class ReportCommentWriteRepository : WriteRepository<ReportComment, ResultReportCommentDto, Guid>, IReportCommentWriteRepository
    {
        public ReportCommentWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}
