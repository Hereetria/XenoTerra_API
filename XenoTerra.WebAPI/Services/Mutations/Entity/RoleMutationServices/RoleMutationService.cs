using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Entity.RoleService;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.RoleMutationServices
{
    public class RoleMutationService(
        IRoleWriteService roleWriteService,
        IMapper mapper
    ) : IRoleMutationService
    {
        private readonly IRoleWriteService _roleWriteService = roleWriteService;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateRolePayload> CreateAsync(CreateRoleDto dto)
        {
            var role = await _roleWriteService.CreateAsync(dto);
            var result = _mapper.Map<ResultRoleDto>(role);

            return Payload<ResultRoleDto>.FromSuccess<CreateRolePayload>(
                "Role created successfully.",
                result
            );
        }

        public async Task<UpdateRolePayload> UpdateAsync(UpdateRoleDto dto, IEnumerable<string> modifiedFields)
        {
            var role = await _roleWriteService.UpdateAsync(dto, modifiedFields);
            var result = _mapper.Map<ResultRoleDto>(role);

            return Payload<ResultRoleDto>.FromSuccess<UpdateRolePayload>(
                "Role updated successfully.",
                result
            );
        }

        public async Task<DeleteRolePayload> DeleteAsync(Guid id)
        {
            var role = await _roleWriteService.DeleteAsync(id);
            var result = _mapper.Map<ResultRoleDto>(role);

            return Payload<ResultRoleDto>.FromSuccess<DeleteRolePayload>(
                "Role deleted successfully.",
                result
            );
        }
    }
}
