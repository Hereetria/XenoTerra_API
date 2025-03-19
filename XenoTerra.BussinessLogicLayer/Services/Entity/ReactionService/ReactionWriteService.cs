using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReactionService
{

    public class ReactionWriteService : WriteService<Reaction, ResultReactionDto, CreateReactionDto, UpdateReactionDto, Guid>, IReactionWriteService
    {
        public ReactionWriteService(IWriteRepository<Reaction, ResultReactionDto, Guid> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
