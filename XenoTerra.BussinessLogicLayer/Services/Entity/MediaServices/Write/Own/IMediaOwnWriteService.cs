using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MediaServices.Write.Own
{

    public interface IMediaOwnWriteService : IWriteService<Media, CreateMediaOwnDto, UpdateMediaOwnDto, Guid> { }

}
