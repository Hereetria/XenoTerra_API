using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportPostServices.Write.Admin
{
    public interface IReportPostAdminWriteService : IWriteService<ReportPost, CreateReportPostAdminDto, UpdateReportPostAdminDto, Guid> { }

}
