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
using XenoTerra.DTOLayer.Dtos.StoryDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryServices.Write.Admin
{
    public class StoryAdminWriteService(
            IWriteRepository<Story, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateStoryAdminDto> createValidator,
            IValidator<UpdateStoryAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Story, CreateStoryAdminDto, UpdateStoryAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IStoryAdminWriteService
    {
        protected override Task PreCreateAsync(CreateStoryAdminDto createDto)
        {
            createDto.CreatedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
