using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using XenoTerra.BussinessLogicLayer.Helpers;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Repositories.Entity.AppRoleRepositories;
using XenoTerra.DataAccessLayer.Helpers.Concrete;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.AppRoleServices.Write.Admin
{
    public class AppRoleAdminWriteService(
        IAppRoleWriteRepository roleWriteRepository,
        IMapper mapper,
        IValidator<CreateAppRoleAdminDto> createValidator,
        IValidator<UpdateAppRoleAdminDto> updateValidator,
        AppDbContext dbContext
    ) : IAppRoleAdminWriteService
    {
        private readonly IAppRoleWriteRepository _roleWriteRepository = roleWriteRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<CreateAppRoleAdminDto> _createValidator = createValidator;
        private readonly IValidator<UpdateAppRoleAdminDto> _updateValidator = updateValidator;
        private readonly AppDbContext _dbContext = dbContext;

        protected virtual Task PreCreateAsync(CreateAppRoleAdminDto createDto) => Task.CompletedTask;
        protected virtual Task PreUpdateAsync(UpdateAppRoleAdminDto updateDto) => Task.CompletedTask;

        public async Task<AppRole> CreateAsync(CreateAppRoleAdminDto createDto)
        {
            ArgumentGuard.EnsureNotNull(createDto);
            await ValidationGuard.ValidateOrThrowAsync(_createValidator, createDto);

            await PreCreateAsync(createDto);

            var role = MappingGuard.MapOrThrow<AppRole, CreateAppRoleAdminDto>(_mapper, createDto);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(_dbContext, ctx =>
                _roleWriteRepository.InsertAsync(role));
        }

        public async Task<AppRole> UpdateAsync(UpdateAppRoleAdminDto updateDto, IEnumerable<string> modifiedFields)
        {
            ArgumentGuard.EnsureNotNull(updateDto);
            await ValidationGuard.ValidateOrThrowAsync(_updateValidator, updateDto);

            await PreUpdateAsync(updateDto);

            var role = MappingGuard.MapOrThrow<AppRole, UpdateAppRoleAdminDto>(_mapper, updateDto);

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
