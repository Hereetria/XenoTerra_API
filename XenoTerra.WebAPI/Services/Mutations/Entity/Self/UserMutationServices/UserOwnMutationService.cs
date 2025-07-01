using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Entity.AppUserServices.Write.Own;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.AuthDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserMutationServices
{
    public class UserOwnMutationService(
        IAppUserOwnWriteService userWriteService,
        IMapper mapper
    ) : IUserOwnMutationService
    {
        private readonly IAppUserOwnWriteService _userWriteService = userWriteService;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateUserOwnPayload> CreateAsync(RegisterDto dto)
        {
            var user = await _userWriteService.CreateAsync(dto);
            var result = _mapper.Map<ResultAppUserOwnDto>(user);

            return Payload<ResultAppUserOwnDto>.FromSuccess<CreateUserOwnPayload>(
                "User created successfully.",
                result
            );
        }

        public async Task<UpdateUserOwnPayload> UpdateAsync(UpdateAppUserOwnDto dto, IEnumerable<string> modifiedFields)
        {
            var user = await _userWriteService.UpdateAsync(dto, modifiedFields);
            var result = _mapper.Map<ResultAppUserOwnDto>(user);

            return Payload<ResultAppUserOwnDto>.FromSuccess<UpdateUserOwnPayload>(
                "User updated successfully.",
                result
            );
        }

        public async Task<DeleteUserOwnPayload> DeleteAsync(Guid id)
        {
            var user = await _userWriteService.DeleteAsync(id);
            var result = _mapper.Map<ResultAppUserOwnDto>(user);

            return Payload<ResultAppUserOwnDto>.FromSuccess<DeleteUserOwnPayload>(
                "User deleted successfully.",
                result
            );
        }
    }
}
