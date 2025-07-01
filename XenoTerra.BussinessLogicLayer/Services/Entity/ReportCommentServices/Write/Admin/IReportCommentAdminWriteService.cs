using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentServices.Write.Admin
{
    public interface IReportCommentAdminWriteService : IWriteService<ReportComment, CreateReportCommentAdminDto, UpdateReportCommentAdminDto, Guid> { }

}
