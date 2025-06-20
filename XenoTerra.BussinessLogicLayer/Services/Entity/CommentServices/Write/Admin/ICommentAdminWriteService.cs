using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.CommentServices.Write.Admin
{
    public interface ICommentAdminWriteService : IWriteService<Comment, CreateCommentAdminDto, UpdateCommentAdminDto, Guid> { }

}
