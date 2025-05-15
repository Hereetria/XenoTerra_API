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
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Repositories.Entity.UserRepository;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserService
{
    public class UserWriteService(
        IUserWriteRepository userWriteRepository,
        IMapper mapper,
        IValidator<RegisterDto> createValidator,
        IValidator<UpdateUserDto> updateValidator,
        AppDbContext dbContext
    ) : IUserWriteService
    {
        private readonly IUserWriteRepository _userWriteRepository = userWriteRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<RegisterDto> _createValidator = createValidator;
        private readonly IValidator<UpdateUserDto> _updateValidator = updateValidator;
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

        protected virtual Task PreUpdateAsync(UpdateUserDto dto) => Task.CompletedTask;

        public async Task<User> CreateAsync(RegisterDto dto)
        {
            ArgumentGuard.EnsureNotNull(dto);
            await ValidationGuard.ValidateOrThrowAsync(_createValidator, dto);

            await PreCreateAsync(dto);

            var user = MappingGuard.MapOrThrow<User, RegisterDto>(_mapper, dto);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(
                _dbContext,
                ctx => _userWriteRepository.InsertAsync(user, dto.Password)
            );
        }

        public async Task<User> UpdateAsync(UpdateUserDto updateDto, IEnumerable<string> modifiedFields)
        {
            ArgumentGuard.EnsureNotNull(updateDto);
            await ValidationGuard.ValidateOrThrowAsync(_updateValidator, updateDto);

            await PreUpdateAsync(updateDto);

            var user = MappingGuard.MapOrThrow<User, UpdateUserDto>(_mapper, updateDto);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(
                _dbContext,
                ctx => _userWriteRepository.ModifyAsync(user, modifiedFields)
            );
        }

        public async Task<User> DeleteAsync(Guid id)
        {
            ArgumentGuard.EnsureValidKey(id);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(_dbContext, ctx =>
                _userWriteRepository.RemoveAsync(id));
        }
    }
}
