using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportPostServices.Write.Own
{
    public interface IReportPostOwnWriteService : IWriteService<ReportPost, CreateReportPostOwnDto, UpdateReportPostOwnDto, Guid> { }

}
