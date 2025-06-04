using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Entity.AppRoleServices;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.RoleMutationServices
{
    public class RoleAdminMutationService(
        IAppRoleWriteService roleWriteService,
        IMapper mapper
    ) : IRoleAdminMutationService
    {
        private readonly IAppRoleWriteService _roleWriteService = roleWriteService;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateRoleAdminPayload> CreateAsync(CreateAppRoleDto dto)
        {
            var role = await _roleWriteService.CreateAsync(dto);
            var result = _mapper.Map<ResultAppRoleDto>(role);

            return Payload<ResultAppRoleDto>.FromSuccess<CreateRoleAdminPayload>(
                "Role created successfully.",
                result
            );
        }

        public async Task<UpdateRoleAdminPayload> UpdateAsync(UpdateAppRoleDto dto, IEnumerable<string> modifiedFields)
        {
            var role = await _roleWriteService.UpdateAsync(dto, modifiedFields);
            var result = _mapper.Map<ResultAppRoleDto>(role);

            return Payload<ResultAppRoleDto>.FromSuccess<UpdateRoleAdminPayload>(
                "Role updated successfully.",
                result
            );
        }

        public async Task<DeleteRoleAdminPayload> DeleteAsync(Guid id)
        {
            var role = await _roleWriteService.DeleteAsync(id);
            var result = _mapper.Map<ResultAppRoleDto>(role);

            return Payload<ResultAppRoleDto>.FromSuccess<DeleteRoleAdminPayload>(
                "Role deleted successfully.",
                result
            );
        }
    }
}
