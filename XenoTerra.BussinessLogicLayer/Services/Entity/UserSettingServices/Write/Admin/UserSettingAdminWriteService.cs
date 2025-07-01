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
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingServices.Write.Admin
{
    public class UserSettingAdminWriteService(
            IWriteRepository<UserSetting, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateUserSettingAdminDto> createValidator,
            IValidator<UpdateUserSettingAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<UserSetting, CreateUserSettingAdminDto, UpdateUserSettingAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IUserSettingAdminWriteService
    {
        protected override Task PreCreateAsync(CreateUserSettingAdminDto createDto)
        {
            createDto.LastUpdated = DateTime.UtcNow;
            return Task.CompletedTask;
        }

        protected override Task PreUpdateAsync(UpdateUserSettingAdminDto updateDto)
        {
            updateDto.LastUpdated = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
