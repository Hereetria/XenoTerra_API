using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.LikeService
{
    public class LikeReadService : ReadService<Like, ResultLikeWithRelationsDto, Guid>, ILikeReadService
    {
        public LikeReadService(IReadRepository<Like, Guid> repository, IMapper mapper, SelectorExpressionProvider<Like, ResultLikeWithRelationsDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }

}
