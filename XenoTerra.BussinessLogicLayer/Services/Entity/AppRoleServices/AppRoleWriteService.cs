using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using XenoTerra.BussinessLogicLayer.Helpers;
using XenoTerra.DataAccessLayer.Helpers;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DataAccessLayer.Repositories.Entity.AppRoleRepositories;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.AppRoleServices
{
    public class AppRoleWriteService(
        IAppRoleWriteRepository roleWriteRepository,
        IMapper mapper,
        IValidator<CreateAppRoleDto> createValidator,
        IValidator<UpdateAppRoleDto> updateValidator,
        AppDbContext dbContext
    ) : IAppRoleWriteService
    {
        private readonly IAppRoleWriteRepository _roleWriteRepository = roleWriteRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<CreateAppRoleDto> _createValidator = createValidator;
        private readonly IValidator<UpdateAppRoleDto> _updateValidator = updateValidator;
        private readonly AppDbContext _dbContext = dbContext;

        protected virtual Task PreCreateAsync(CreateAppRoleDto createDto) => Task.CompletedTask;
        protected virtual Task PreUpdateAsync(UpdateAppRoleDto updateDto) => Task.CompletedTask;

        public async Task<AppRole> CreateAsync(CreateAppRoleDto createDto)
        {
            ArgumentGuard.EnsureNotNull(createDto);
            await ValidationGuard.ValidateOrThrowAsync(_createValidator, createDto);

            await PreCreateAsync(createDto);

            var role = MappingGuard.MapOrThrow<AppRole, CreateAppRoleDto>(_mapper, createDto);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(_dbContext, ctx =>
                _roleWriteRepository.InsertAsync(role));
        }

        public async Task<AppRole> UpdateAsync(UpdateAppRoleDto updateDto, IEnumerable<string> modifiedFields)
        {
            ArgumentGuard.EnsureNotNull(updateDto);
            await ValidationGuard.ValidateOrThrowAsync(_updateValidator, updateDto);

            await PreUpdateAsync(updateDto);

            var role = MappingGuard.MapOrThrow<AppRole, UpdateAppRoleDto>(_mapper, updateDto);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(_dbContext, ctx =>
                _roleWriteRepository.ModifyAsync(role, modifiedFields));
        }

        public async Task<AppRole> DeleteAsync(Guid id)
        {
            ArgumentGuard.EnsureValidKey(id);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(_dbContext, ctx =>
                _roleWriteRepository.RemoveAsync(id));
        }
    }
}
