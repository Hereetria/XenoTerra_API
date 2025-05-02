using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using XenoTerra.BussinessLogicLayer.Helpers;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Entity.RoleRepository;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.RoleService
{
    public class RoleWriteService(
        IRoleWriteRepository roleWriteRepository,
        IMapper mapper,
        IValidator<CreateRoleDto> createValidator,
        IValidator<UpdateRoleDto> updateValidator,
        AppDbContext dbContext
    ) : IRoleWriteService
    {
        private readonly IRoleWriteRepository _roleWriteRepository = roleWriteRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<CreateRoleDto> _createValidator = createValidator;
        private readonly IValidator<UpdateRoleDto> _updateValidator = updateValidator;
        private readonly AppDbContext _dbContext = dbContext;

        protected virtual Task PreCreateAsync(CreateRoleDto createDto) => Task.CompletedTask;
        protected virtual Task PreUpdateAsync(UpdateRoleDto updateDto) => Task.CompletedTask;

        public async Task<IdentityRole<Guid>> CreateAsync(CreateRoleDto createDto)
        {
            ArgumentGuard.EnsureNotNull(createDto);
            await ValidationGuard.ValidateOrThrowAsync(_createValidator, createDto);

            await PreCreateAsync(createDto);

            var role = MappingGuard.MapOrThrow<IdentityRole<Guid>, CreateRoleDto>(_mapper, createDto);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(_dbContext, ctx =>
                _roleWriteRepository.InsertAsync(role));
        }

        public async Task<IdentityRole<Guid>> UpdateAsync(UpdateRoleDto updateDto, IEnumerable<string> modifiedFields)
        {
            ArgumentGuard.EnsureNotNull(updateDto);
            await ValidationGuard.ValidateOrThrowAsync(_updateValidator, updateDto);

            await PreUpdateAsync(updateDto);

            var role = MappingGuard.MapOrThrow<IdentityRole<Guid>, UpdateRoleDto>(_mapper, updateDto);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(_dbContext, ctx =>
                _roleWriteRepository.ModifyAsync(role, modifiedFields));
        }

        public async Task<IdentityRole<Guid>> DeleteAsync(Guid id)
        {
            ArgumentGuard.EnsureValidKey(id);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(_dbContext, ctx =>
                _roleWriteRepository.RemoveAsync(id));
        }
    }
}
