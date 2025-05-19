using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Entity.RoleServices;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.RoleMutationServices
{
    public class RoleAdminMutationService(
        IRoleWriteService roleWriteService,
        IMapper mapper
    ) : IRoleAdminMutationService
    {
        private readonly IRoleWriteService _roleWriteService = roleWriteService;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateRoleAdminPayload> CreateAsync(CreateRoleDto dto)
        {
            var role = await _roleWriteService.CreateAsync(dto);
            var result = _mapper.Map<ResultRoleDto>(role);

            return Payload<ResultRoleDto>.FromSuccess<CreateRoleAdminPayload>(
                "Role created successfully.",
                result
            );
        }

        public async Task<UpdateRoleAdminPayload> UpdateAsync(UpdateRoleDto dto, IEnumerable<string> modifiedFields)
        {
            var role = await _roleWriteService.UpdateAsync(dto, modifiedFields);
            var result = _mapper.Map<ResultRoleDto>(role);

            return Payload<ResultRoleDto>.FromSuccess<UpdateRoleAdminPayload>(
                "Role updated successfully.",
                result
            );
        }

        public async Task<DeleteRoleAdminPayload> DeleteAsync(Guid id)
        {
            var role = await _roleWriteService.DeleteAsync(id);
            var result = _mapper.Map<ResultRoleDto>(role);

            return Payload<ResultRoleDto>.FromSuccess<DeleteRoleAdminPayload>(
                "Role deleted successfully.",
                result
            );
        }
    }
}
