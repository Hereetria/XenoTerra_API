using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.LikeService
{
    public class LikeReadService(IReadRepository<Like, Guid> readRepository) : ReadService<Like, Guid>(readRepository), ILikeReadService
    {
    }
}
