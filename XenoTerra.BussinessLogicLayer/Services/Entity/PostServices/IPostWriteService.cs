using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostServices
{

    public interface IPostWriteService : IWriteService<Post, CreatePostDto, UpdatePostDto, Guid> { }
}
