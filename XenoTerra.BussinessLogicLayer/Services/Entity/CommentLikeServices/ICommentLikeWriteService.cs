using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.CommentLikeServices
{
    public interface ICommentLikeWriteService : IWriteService<CommentLike, CreateCommentLikeDto, UpdateCommentLikeDto, Guid> { }

}
