using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentService
{
    public interface IReportCommentWriteService : IWriteService<ReportComment, CreateReportCommentDto, UpdateReportCommentDto, Guid> { }

}
