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
using XenoTerra.DTOLayer.Dtos.ReactionDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReactionServices.Write.Own
{
    public class ReactionOwnWriteService(
            IWriteRepository<Reaction, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateReactionOwnDto> createValidator,
            IValidator<UpdateReactionOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Reaction, CreateReactionOwnDto, UpdateReactionOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IReactionOwnWriteService
    {
    }
}
