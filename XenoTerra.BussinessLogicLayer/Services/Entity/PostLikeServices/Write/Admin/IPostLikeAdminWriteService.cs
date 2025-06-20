using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.PostLikeAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostLikeServices.Write.Admin
{
    public interface IPostLikeAdminWriteService : IWriteService<PostLike, CreatePostLikeAdminDto, UpdatePostLikeAdminDto, Guid> { }

}
