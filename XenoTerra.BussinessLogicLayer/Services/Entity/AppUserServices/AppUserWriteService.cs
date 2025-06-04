using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Exceptions.Technical;
using XenoTerra.BussinessLogicLayer.Helpers;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Helpers;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DataAccessLayer.Repositories.Entity.AppUserRepositories;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.AppUserServices
{
    public class AppUserWriteService(
        IAppUserWriteRepository userWriteRepository,
        IMapper mapper,
        IValidator<RegisterDto> createValidator,
        IValidator<UpdateAppUserDto> updateValidator,
        AppDbContext dbContext
    ) : IAppUserWriteService
    {
        private readonly IAppUserWriteRepository _userWriteRepository = userWriteRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<RegisterDto> _createValidator = createValidator;
        private readonly IValidator<UpdateAppUserDto> _updateValidator = updateValidator;
        private readonly AppDbContext _dbContext = dbContext;

        protected virtual Task PreCreateAsync(RegisterDto dto)
        {
            dto.Bio = string.Empty;
            dto.ProfilePicture = string.Empty;
            dto.Website = string.Empty;
            dto.FollowersCount = 0;
            dto.FollowingCount = 0;
            dto.IsVerified = false;
            dto.LastActive = DateTime.UtcNow;

            return Task.CompletedTask;
        }

        protected virtual Task PreUpdateAsync(UpdateAppUserDto dto) => Task.CompletedTask;

        public async Task<AppUser> CreateAsync(RegisterDto dto)
        {
            ArgumentGuard.EnsureNotNull(dto);
            await ValidationGuard.ValidateOrThrowAsync(_createValidator, dto);

            await PreCreateAsync(dto);

            var user = MappingGuard.MapOrThrow<AppUser, RegisterDto>(_mapper, dto);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(
                _dbContext,
                ctx => _userWriteRepository.InsertAsync(user, dto.Password)
            );
        }

        public async Task<AppUser> UpdateAsync(UpdateAppUserDto updateDto, IEnumerable<string> modifiedFields)
        {
            ArgumentGuard.EnsureNotNull(updateDto);
            await ValidationGuard.ValidateOrThrowAsync(_updateValidator, updateDto);

            await PreUpdateAsync(updateDto);

            var user = MappingGuard.MapOrThrow<AppUser, UpdateAppUserDto>(_mapper, updateDto);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(
                _dbContext,
                ctx => _userWriteRepository.ModifyAsync(user, modifiedFields)
            );
        }

        public async Task<AppUser> DeleteAsync(Guid id)
        {
            ArgumentGuard.EnsureValidKey(id);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(_dbContext, ctx =>
                _userWriteRepository.RemoveAsync(id));
        }
    }
}
