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
using XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MediaServices.Write.Own
{
    public class MediaOwnWriteService(
            IWriteRepository<Media, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateMediaOwnDto> createValidator,
            IValidator<UpdateMediaOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Media, CreateMediaOwnDto, UpdateMediaOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IMediaOwnWriteService
    {
        protected override Task PreCreateAsync(CreateMediaOwnDto createDto)
        {
            createDto.UploadedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
