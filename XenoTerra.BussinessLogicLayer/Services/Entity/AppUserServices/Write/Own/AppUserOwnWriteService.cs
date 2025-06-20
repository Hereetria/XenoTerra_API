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
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Repositories.Entity.AppUserRepositories;
using XenoTerra.DataAccessLayer.Helpers.Concrete;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.AuthDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.AppUserServices.Write.Own
{
    public class AppUserOwnWriteService(
        IAppUserWriteRepository userWriteRepository,
        IMapper mapper,
        IValidator<RegisterDto> createValidator,
        IValidator<UpdateAppUserOwnDto> updateValidator,
        AppDbContext dbContext
    ) : IAppUserOwnWriteService
    {
        private readonly IAppUserWriteRepository _userWriteRepository = userWriteRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<RegisterDto> _createValidator = createValidator;
        private readonly IValidator<UpdateAppUserOwnDto> _updateValidator = updateValidator;
        private readonly AppDbContext _dbContext = dbContext;

        protected virtual Task PreCreateAsync(RegisterDto dto)
        {
            return Task.CompletedTask;
        }

        protected virtual Task PreUpdateAsync(UpdateAppUserOwnDto dto) => Task.CompletedTask;

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

        public async Task<AppUser> UpdateAsync(UpdateAppUserOwnDto updateDto, IEnumerable<string> modifiedFields)
        {
            ArgumentGuard.EnsureNotNull(updateDto);
            await ValidationGuard.ValidateOrThrowAsync(_updateValidator, updateDto);

            await PreUpdateAsync(updateDto);

            var user = MappingGuard.MapOrThrow<AppUser, UpdateAppUserOwnDto>(_mapper, updateDto);

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
