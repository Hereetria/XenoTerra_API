using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.FollowService
{
    public class FollowReadService : ReadService<Follow, ResultFollowWithRelationsDto, Guid>, IFollowReadService
    {
        public FollowReadService(IReadRepository<Follow, Guid> repository, IMapper mapper, SelectorExpressionProvider<Follow, ResultFollowWithRelationsDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }
}
