using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Entity.AppUserServices;
using XenoTerra.DTOLayer.Dto.AppUserDto.Admin;
using XenoTerra.DTOLayer.Dto.AppUserDto.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.UserAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserMutationServices
{
    public class UserAdminMutationService(
        IAppUserWriteService userWriteService,
        IMapper mapper
    ) : IUserAdminMutationService
    {
        private readonly IAppUserWriteService _userWriteService = userWriteService;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateUserAdminPayload> CreateAsync(RegisterAdminDto dto)
        {
            var user = await _userWriteService.CreateAsync(dto);
            var result = _mapper.Map<ResultAppUserOwnAdminDto>(user);

            return Payload<ResultAppUserOwnAdminDto>.FromSuccess<CreateUserAdminPayload>(
                "User created successfully.",
                result
            );
        }

        public async Task<UpdateUserAdminPayload> UpdateAsync(UpdateAppUserAdminDto dto, IEnumerable<string> modifiedFields)
        {
            var user = await _userWriteService.UpdateAsync(dto, modifiedFields);
            var result = _mapper.Map<ResultAppUserOwnAdminDto>(user);

            return Payload<ResultAppUserOwnAdminDto>.FromSuccess<UpdateUserAdminPayload>(
                "User updated successfully.",
                result
            );
        }

        public async Task<DeleteUserAdminPayload> DeleteAsync(Guid id)
        {
            var user = await _userWriteService.DeleteAsync(id);
            var result = _mapper.Map<ResultAppUserOwnAdminDto>(user);

            return Payload<ResultAppUserOwnAdminDto>.FromSuccess<DeleteUserAdminPayload>(
                "User deleted successfully.",
                result
            );
        }
    }
}