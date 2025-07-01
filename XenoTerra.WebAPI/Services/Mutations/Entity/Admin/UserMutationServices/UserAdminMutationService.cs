using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Entity.AppUserServices.Write.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AuthDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserMutationServices
{
    public class UserAdminMutationService(
        IAppUserAdminWriteService userWriteService,
        IMapper mapper
    ) : IUserAdminMutationService
    {
        private readonly IAppUserAdminWriteService _userWriteService = userWriteService;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateUserAdminPayload> CreateAsync(RegisterDto dto)
        {
            var user = await _userWriteService.CreateAsync(dto);
            var result = _mapper.Map<ResultAppUserAdminDto>(user);

            return Payload<ResultAppUserAdminDto>.FromSuccess<CreateUserAdminPayload>(
                "User created successfully.",
                result
            );
        }

        public async Task<UpdateUserAdminPayload> UpdateAsync(UpdateAppUserAdminDto dto, IEnumerable<string> modifiedFields)
        {
            var user = await _userWriteService.UpdateAsync(dto, modifiedFields);
            var result = _mapper.Map<ResultAppUserAdminDto>(user);

            return Payload<ResultAppUserAdminDto>.FromSuccess<UpdateUserAdminPayload>(
                "User updated successfully.",
                result
            );
        }

        public async Task<DeleteUserAdminPayload> DeleteAsync(Guid id)
        {
            var user = await _userWriteService.DeleteAsync(id);
            var result = _mapper.Map<ResultAppUserAdminDto>(user);

            return Payload<ResultAppUserAdminDto>.FromSuccess<DeleteUserAdminPayload>(
                "User deleted successfully.",
                result
            );
        }
    }
}