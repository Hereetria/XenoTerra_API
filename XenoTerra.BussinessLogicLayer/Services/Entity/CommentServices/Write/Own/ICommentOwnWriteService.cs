using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.CommentServices.Write.Own
{
    public interface ICommentOwnWriteService : IWriteService<Comment, CreateCommentOwnDto, UpdateCommentOwnDto, Guid> { }

}
