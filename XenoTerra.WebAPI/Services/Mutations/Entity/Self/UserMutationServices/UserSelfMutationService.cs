using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserServices;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserMutationServices
{
    public class UserSelfMutationService(
        IUserWriteService userWriteService,
        IMapper mapper
    ) : IUserSelfMutationService
    {
        private readonly IUserWriteService _userWriteService = userWriteService;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateUserSelfPayload> CreateAsync(RegisterDto dto)
        {
            var user = await _userWriteService.CreateAsync(dto);
            var result = _mapper.Map<ResultUserPrivateDto>(user);

            return Payload<ResultUserPrivateDto>.FromSuccess<CreateUserSelfPayload>(
                "User created successfully.",
                result
            );
        }

        public async Task<UpdateUserSelfPayload> UpdateAsync(UpdateUserDto dto, IEnumerable<string> modifiedFields)
        {
            var user = await _userWriteService.UpdateAsync(dto, modifiedFields);
            var result = _mapper.Map<ResultUserPrivateDto>(user);

            return Payload<ResultUserPrivateDto>.FromSuccess<UpdateUserSelfPayload>(
                "User updated successfully.",
                result
            );
        }

        public async Task<DeleteUserSelfPayload> DeleteAsync(Guid id)
        {
            var user = await _userWriteService.DeleteAsync(id);
            var result = _mapper.Map<ResultUserPrivateDto>(user);

            return Payload<ResultUserPrivateDto>.FromSuccess<DeleteUserSelfPayload>(
                "User deleted successfully.",
                result
            );
        }
    }
}
