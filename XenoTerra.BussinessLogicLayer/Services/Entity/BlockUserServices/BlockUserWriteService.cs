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
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserServices
{
    public class BlockUserWriteService(
        IWriteRepository<BlockUser, Guid> writeRepository,
        IMapper mapper,
        IValidator<CreateCommentckUserDto> createValidator,
        IValidator<UpdateBlockUserDto> updateValidator,
        AppDbContext dbContext
    )
        : WriteService<BlockUser, CreateCommentckUserDto, UpdateBlockUserDto, Guid>(
            writeRepository,
            mapper,
            createValidator,
            updateValidator,
            dbContext
        ),
        IBlockUserWriteService
    {
        protected override Task PreCreateAsync(CreateCommentckUserDto createDto)
        {
            createDto.BlockedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
