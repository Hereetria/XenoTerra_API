using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReactionService
{
    public class ReactionReadService : ReadService<Reaction, ResultReactionWithRelationsDto, Guid>, IReactionReadService
    {
        public ReactionReadService(IReadRepository<Reaction, ResultReactionWithRelationsDto, Guid> repository, IMapper mapper)
            : base(repository) { }
    }
}
