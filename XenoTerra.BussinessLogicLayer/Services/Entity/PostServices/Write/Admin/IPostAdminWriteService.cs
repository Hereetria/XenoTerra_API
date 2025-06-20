using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostServices.Write.Admin
{

    public interface IPostAdminWriteService : IWriteService<Post, CreatePostAdminDto, UpdatePostAdminDto, Guid> { }
}
