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
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Self.Own;
using XenoTerra.BussinessLogicLayer.Helpers;
using XenoTerra.DataAccessLayer.Helpers.Concrete;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingServices.Write.Own
{
    public class UserSettingOwnWriteService(
        IWriteRepository<UserSetting, Guid> writeRepository,
        IMapper mapper,
        IValidator<UpdateUserSettingOwnDto> updateValidator,
        AppDbContext dbContext)
        : IUserSettingOwnWriteService
    {
        protected readonly IWriteRepository<UserSetting, Guid> _writeRepository = writeRepository;
        protected readonly IMapper _mapper = mapper;
        protected readonly IValidator<UpdateUserSettingOwnDto> _updateValidator = updateValidator;
        protected readonly AppDbContext _dbContext = dbContext;

        public async Task<UserSetting> UpdateUserSettingAsync(UpdateUserSettingOwnDto updateDto, IEnumerable<string> modifiedFields)
        {
            ArgumentGuard.EnsureNotNull(updateDto);

            await PreUpdateAsync(updateDto);
            await ValidationGuard.ValidateOrThrowAsync(_updateValidator, updateDto);

            var entity = MappingGuard.MapOrThrow<UserSetting, UpdateUserSettingOwnDto>(_mapper, updateDto);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(
                _dbContext,
                ctx => _writeRepository.ModifyAsync(entity, modifiedFields)
            );
        }

        public async Task<UserSetting> DeleteUserSettingAsync(Guid key)
        {
            ArgumentGuard.EnsureValidKey(key);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(
                _dbContext,
                ctx => _writeRepository.RemoveAsync(key)
            );
        }

        protected static Task PreUpdateAsync(UpdateUserSettingOwnDto updateDto)
        {
            updateDto.LastUpdated = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
