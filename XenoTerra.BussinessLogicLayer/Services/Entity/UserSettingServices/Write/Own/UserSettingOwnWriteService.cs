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
using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingServices.Write.Own
{
    public class UserSettingOwnWriteService(
            IWriteRepository<UserSetting, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateUserSettingOwnDto> createValidator,
            IValidator<UpdateUserSettingOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<UserSetting, CreateUserSettingOwnDto, UpdateUserSettingOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IUserSettingOwnWriteService
    {
        protected override Task PreCreateAsync(CreateUserSettingOwnDto createDto)
        {
            createDto.LastUpdated = DateTime.UtcNow;
            return Task.CompletedTask;
        }

        protected override Task PreUpdateAsync(UpdateUserSettingOwnDto updateDto)
        {
            updateDto.LastUpdated = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
