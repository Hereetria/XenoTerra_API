using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.ReactionDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReactionServices.Write.Own
{
    public interface IReactionOwnWriteService : IWriteService<Reaction, CreateReactionOwnDto, UpdateReactionOwnDto, Guid> { }

}
