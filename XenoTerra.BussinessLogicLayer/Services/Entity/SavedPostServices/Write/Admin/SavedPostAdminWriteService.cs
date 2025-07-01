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
using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostServices.Write.Admin
{
    public class SavedPostAdminWriteService(
            IWriteRepository<SavedPost, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateSavedPostAdminDto> createValidator,
            IValidator<UpdateSavedPostAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<SavedPost, CreateSavedPostAdminDto, UpdateSavedPostAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            ISavedPostAdminWriteService
    {
        protected override Task PreCreateAsync(CreateSavedPostAdminDto createDto)
        {
            createDto.SavedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
