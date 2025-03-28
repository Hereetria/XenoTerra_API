using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReactionService
{
    public class ReactionWriteService(
            IWriteRepository<Reaction, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateReactionDto> createValidator,
            IValidator<UpdateReactionDto> updateValidator
        )
            : WriteService<Reaction, CreateReactionDto, UpdateReactionDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            IReactionWriteService
    {
    }
}
