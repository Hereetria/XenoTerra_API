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
using XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserServices.Write.Admin
{
    public class BlockUserAdminWriteService(
        IWriteRepository<BlockUser, Guid> writeRepository,
        IMapper mapper,
        IValidator<CreateBlockUserAdminDto> createValidator,
        IValidator<UpdateBlockUserAdminDto> updateValidator,
        AppDbContext dbContext
    )
        : WriteService<BlockUser, CreateBlockUserAdminDto, UpdateBlockUserAdminDto, Guid>(
            writeRepository,
            mapper,
            createValidator,
            updateValidator,
            dbContext
        ),
        IBlockUserAdminWriteService
    {
        protected override Task PreCreateAsync(CreateBlockUserAdminDto createDto)
        {
            createDto.BlockedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
