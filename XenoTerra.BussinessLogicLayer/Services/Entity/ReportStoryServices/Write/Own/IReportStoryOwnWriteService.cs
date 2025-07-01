using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportStoryServices.Write.Own
{
    public interface IReportStoryOwnWriteService : IWriteService<ReportStory, CreateReportStoryOwnDto, UpdateReportStoryOwnDto, Guid> { }

}
