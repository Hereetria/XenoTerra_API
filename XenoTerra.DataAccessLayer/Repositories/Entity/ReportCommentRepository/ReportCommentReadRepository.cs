﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.ReportCommentRepository
{
    public class ReportCommentReadRepository : ReadRepository<ReportComment, Guid>, IReportCommentReadRepository
    {
        public ReportCommentReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
