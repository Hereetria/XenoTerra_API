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
using XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryServices.Write.Admin
{
    public class ViewStoryAdminWriteService(
            IWriteRepository<ViewStory, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateViewStoryAdminDto> createValidator,
            IValidator<UpdateViewStoryAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<ViewStory, CreateViewStoryAdminDto, UpdateViewStoryAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IViewStoryAdminWriteService
    {
        protected override Task PreCreateAsync(CreateViewStoryAdminDto createDto)
        {
            createDto.ViewedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
