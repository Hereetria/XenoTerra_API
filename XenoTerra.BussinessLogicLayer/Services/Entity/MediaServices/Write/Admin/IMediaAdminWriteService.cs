using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.MediaDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MediaServices.Write.Admin
{

    public interface IMediaAdminWriteService : IWriteService<Media, CreateMediaAdminDto, UpdateMediaAdminDto, Guid> { }

}
