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
using XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReactionServices.Write.Admin
{
    public class ReactionAdminWriteService(
            IWriteRepository<Reaction, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateReactionAdminDto> createValidator,
            IValidator<UpdateReactionAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Reaction, CreateReactionAdminDto, UpdateReactionAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IReactionAdminWriteService
    {
    }
}
