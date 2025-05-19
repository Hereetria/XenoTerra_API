using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserServices;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserMutationServices
{
    public class UserAdminMutationService(
        IUserWriteService userWriteService,
        IMapper mapper
    ) : IUserAdminMutationService
    {
        private readonly IUserWriteService _userWriteService = userWriteService;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateUserAdminPayload> CreateAsync(RegisterDto dto)
        {
            var user = await _userWriteService.CreateAsync(dto);
            var result = _mapper.Map<ResultUserPrivateDto>(user);

            return Payload<ResultUserPrivateDto>.FromSuccess<CreateUserAdminPayload>(
                "User created successfully.",
                result
            );
        }

        public async Task<UpdateUserAdminPayload> UpdateAsync(UpdateUserDto dto, IEnumerable<string> modifiedFields)
        {
            var user = await _userWriteService.UpdateAsync(dto, modifiedFields);
            var result = _mapper.Map<ResultUserPrivateDto>(user);

            return Payload<ResultUserPrivateDto>.FromSuccess<UpdateUserAdminPayload>(
                "User updated successfully.",
                result
            );
        }

        public async Task<DeleteUserAdminPayload> DeleteAsync(Guid id)
        {
            var user = await _userWriteService.DeleteAsync(id);
            var result = _mapper.Map<ResultUserPrivateDto>(user);

            return Payload<ResultUserPrivateDto>.FromSuccess<DeleteUserAdminPayload>(
                "User deleted successfully.",
                result
            );
        }
    }
}
