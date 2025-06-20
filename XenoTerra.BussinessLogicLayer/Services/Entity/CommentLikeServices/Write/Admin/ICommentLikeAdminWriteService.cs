using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.CommentLikeServices.Write.Admin
{
    public interface ICommentLikeAdminWriteService : IWriteService<CommentLike, CreateCommentLikeAdminDto, UpdateCommentLikeAdminDto, Guid> { }

}
