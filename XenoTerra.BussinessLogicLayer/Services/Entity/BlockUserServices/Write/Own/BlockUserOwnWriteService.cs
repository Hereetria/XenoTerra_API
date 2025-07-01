using AutoMapper;
using FluentValidation;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserServices.Write.Own
{
    public class BlockUserOwnWriteService(
        IWriteRepository<BlockUser, Guid> writeRepository,
        IMapper mapper,
        IValidator<CreateBlockUserOwnDto> createValidator,
        IValidator<UpdateBlockUserOwnDto> updateValidator,
        AppDbContext dbContext
    )
        : WriteService<BlockUser, CreateBlockUserOwnDto, UpdateBlockUserOwnDto, Guid>(
            writeRepository,
            mapper,
            createValidator,
            updateValidator,
            dbContext
        ),
        IBlockUserOwnWriteService
    {
        protected override Task PreCreateAsync(CreateBlockUserOwnDto createDto)
        {
            createDto.BlockedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
