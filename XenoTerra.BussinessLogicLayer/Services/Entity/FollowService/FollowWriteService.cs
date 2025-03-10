using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.FollowService
{

    public class FollowWriteService : WriteService<Follow, ResultFollowDto, CreateFollowDto, UpdateFollowDto, Guid>, IFollowWriteService
    {
        public FollowWriteService(IWriteRepository<Follow, Guid> repository, IMapper mapper, SelectorExpressionProvider<Follow, ResultFollowDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }
}
