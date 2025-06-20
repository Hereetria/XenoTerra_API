using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
using XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MediaServices.Write.Admin
{
    public class MediaAdminWriteService(
            IWriteRepository<Media, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateMediaAdminDto> createValidator,
            IValidator<UpdateMediaAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Media, CreateMediaAdminDto, UpdateMediaAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IMediaAdminWriteService
    {
        protected override Task PreCreateAsync(CreateMediaAdminDto createDto)
        {
            createDto.UploadedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
