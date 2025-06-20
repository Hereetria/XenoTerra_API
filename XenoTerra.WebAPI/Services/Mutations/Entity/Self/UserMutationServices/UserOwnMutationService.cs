using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Entity.AppUserServices;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Own.Own;
using XenoTerra.DTOLayer.Dtos.AuthDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Own.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.UserMutationServices
{
    public class UserOwnMutationService(
        IAppUserWriteService userWriteService,
        IMapper mapper
    ) : IUserOwnMutationService
    {
        private readonly IAppUserWriteService _userWriteService = userWriteService;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateUserOwnPayload> CreateAsync(RegisterOwnDto dto)
        {
            var user = await _userWriteService.CreateAsync(dto);
            var result = _mapper.Map<ResultAppUserOwnOwnDto>(user);

            return Payload<ResultAppUserOwnOwnDto>.FromSuccess<CreateUserOwnPayload>(
                "User created successfully.",
                result
            );
        }

        public async Task<UpdateUserOwnPayload> UpdateAsync(UpdateAppUserAdminOwnDto dto, IEnumerable<string> modifiedFields)
        {
            var user = await _userWriteService.UpdateAsync(dto, modifiedFields);
            var result = _mapper.Map<ResultAppUserOwnOwnDto>(user);

            return Payload<ResultAppUserOwnOwnDto>.FromSuccess<UpdateUserOwnPayload>(
                "User updated successfully.",
                result
            );
        }

        public async Task<DeleteUserOwnPayload> DeleteAsync(Guid id)
        {
            var user = await _userWriteService.DeleteAsync(id);
            var result = _mapper.Map<ResultAppUserOwnOwnDto>(user);

            return Payload<ResultAppUserOwnOwnDto>.FromSuccess<DeleteUserOwnPayload>(
                "User deleted successfully.",
                result
            );
        }
    }
}
