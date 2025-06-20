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
using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostServices.Write.Own
{
    public class SavedPostOwnWriteService(
            IWriteRepository<SavedPost, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateSavedPostOwnDto> createValidator,
            IValidator<UpdateSavedPostOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<SavedPost, CreateSavedPostOwnDto, UpdateSavedPostOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            ISavedPostOwnWriteService
    {
        protected override Task PreCreateAsync(CreateSavedPostOwnDto createDto)
        {
            createDto.SavedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
