using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReactionService
{
    public class ReactionReadService(IReadRepository<Reaction, Guid> readRepository) : ReadService<Reaction, Guid>(readRepository), IReactionReadService
    {
    }
}
