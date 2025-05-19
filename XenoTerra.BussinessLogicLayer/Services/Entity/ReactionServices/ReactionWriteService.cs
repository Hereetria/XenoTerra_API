using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReactionServices
{
    public class ReactionWriteService(
            IWriteRepository<Reaction, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateReactionDto> createValidator,
            IValidator<UpdateReactionDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Reaction, CreateReactionDto, UpdateReactionDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IReactionWriteService
    {
    }
}
