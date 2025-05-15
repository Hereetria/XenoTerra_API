using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserService;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.UserMutationServices
{
    public class UserMutationService(
        IUserWriteService userWriteService,
        IMapper mapper
    ) : IUserMutationService
    {
        private readonly IUserWriteService _userWriteService = userWriteService;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateUserPayload> CreateAsync(RegisterDto dto)
        {
            var user = await _userWriteService.CreateAsync(dto);
            var result = _mapper.Map<ResultUserDto>(user);

            return Payload<ResultUserDto>.FromSuccess<CreateUserPayload>(
                "User created successfully.",
                result
            );
        }

        public async Task<UpdateUserPayload> UpdateAsync(UpdateUserDto dto, IEnumerable<string> modifiedFields)
        {
            var user = await _userWriteService.UpdateAsync(dto, modifiedFields);
            var result = _mapper.Map<ResultUserDto>(user);

            return Payload<ResultUserDto>.FromSuccess<UpdateUserPayload>(
                "User updated successfully.",
                result
            );
        }

        public async Task<DeleteUserPayload> DeleteAsync(Guid id)
        {
            var user = await _userWriteService.DeleteAsync(id);
            var result = _mapper.Map<ResultUserDto>(user);

            return Payload<ResultUserDto>.FromSuccess<DeleteUserPayload>(
                "User deleted successfully.",
                result
            );
        }
    }
}
