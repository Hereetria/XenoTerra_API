using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostService
{
    public class PostReadService(IReadRepository<Post, Guid> readRepository) : ReadService<Post, Guid>(readRepository), IPostReadService
    {
    }
}
