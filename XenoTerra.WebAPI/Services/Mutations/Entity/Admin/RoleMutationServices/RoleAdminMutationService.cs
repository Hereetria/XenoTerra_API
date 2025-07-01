using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Entity.AppRoleServices;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.BussinessLogicLayer.Services.Entity.AppRoleServices.Write.Admin;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.RoleMutationServices
{
    public class RoleAdminMutationService(
        IAppRoleAdminWriteService roleWriteService,
        IMapper mapper
    ) : IRoleAdminMutationService
    {
        private readonly IAppRoleAdminWriteService _roleWriteService = roleWriteService;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateRoleAdminPayload> CreateAsync(CreateAppRoleAdminDto dto)
        {
            var role = await _roleWriteService.CreateAsync(dto);
            var result = _mapper.Map<ResultAppRoleAdminDto>(role);

            return Payload<ResultAppRoleAdminDto>.FromSuccess<CreateRoleAdminPayload>(
                "Role created successfully.",
                result
            );
        }

        public async Task<UpdateRoleAdminPayload> UpdateAsync(UpdateAppRoleAdminDto dto, IEnumerable<string> modifiedFields)
        {
            var role = await _roleWriteService.UpdateAsync(dto, modifiedFields);
            var result = _mapper.Map<ResultAppRoleAdminDto>(role);

            return Payload<ResultAppRoleAdminDto>.FromSuccess<UpdateRoleAdminPayload>(
                "Role updated successfully.",
                result
            );
        }

        public async Task<DeleteRoleAdminPayload> DeleteAsync(Guid id)
        {
            var role = await _roleWriteService.DeleteAsync(id);
            var result = _mapper.Map<ResultAppRoleAdminDto>(role);

            return Payload<ResultAppRoleAdminDto>.FromSuccess<DeleteRoleAdminPayload>(
                "Role deleted successfully.",
                result
            );
        }
    }
}