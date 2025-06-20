using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostServices.Write.Own
{

    public interface IPostOwnWriteService : IWriteService<Post, CreatePostOwnDto, UpdatePostOwnDto, Guid> { }
}
