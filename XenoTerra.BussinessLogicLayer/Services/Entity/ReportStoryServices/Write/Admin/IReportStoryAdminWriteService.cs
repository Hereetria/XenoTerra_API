using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.ReportStoryAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportStoryServices.Write.Admin
{
    public interface IReportStoryAdminWriteService : IWriteService<ReportStory, CreateReportStoryAdminDto, UpdateReportStoryAdminDto, Guid> { }

}
