using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostLikeServices.Write.Own
{
    public interface IPostLikeOwnWriteService : IWriteService<PostLike, CreatePostLikeOwnDto, UpdatePostLikeOwnDto, Guid> { }

}
