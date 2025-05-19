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
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingServices
{
    public class UserSettingWriteService(
            IWriteRepository<UserSetting, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateUserSettingDto> createValidator,
            IValidator<UpdateUserSettingDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<UserSetting, CreateUserSettingDto, UpdateUserSettingDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IUserSettingWriteService
    {
        protected override Task PreCreateAsync(CreateUserSettingDto createDto)
        {
            createDto.LastUpdated = DateTime.UtcNow;
            return Task.CompletedTask;
        }

        protected override Task PreUpdateAsync(UpdateUserSettingDto updateDto)
        {
            updateDto.LastUpdated = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
