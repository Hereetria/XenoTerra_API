using AutoMapper;
using FluentValidation;
using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations
{
    public class BlockUserMutation(IMapper mapper)
    {
        private readonly MutationService<BlockUser, ResultBlockUserDto, CreateBlockUserDto, UpdateBlockUserDto, Guid> _mutationService = new(mapper);

        public async Task<CreateBlockUserPayload> CreateBlockUserAsync(
            [Service] IWriteService<BlockUser, CreateBlockUserDto, UpdateBlockUserDto, Guid> writeService,
            CreateBlockUserDto? input)
        {
            var result = await _mutationService.CreateAsync(writeService, input);

            return result.Success
                ? new CreateBlockUserSuccessPayload(result.Message, result.Result!)
                : new CreateBlockUserFailurePayload(result.Message, result.Errors ?? []);
        }

        public async Task<UpdateBlockUserPayload> UpdateBlockUserAsync(
            [Service] IWriteService<BlockUser, CreateBlockUserDto, UpdateBlockUserDto, Guid> writeService,
            UpdateBlockUserDto? input)
        {
            var result = await _mutationService.UpdateAsync(writeService, input);

            return result.Success
                ? new UpdateBlockUserSuccessPayload(result.Message, result.Result!)
                : new UpdateBlockUserFailurePayload(result.Message, result.Errors ?? []);
        }

        public async Task<DeleteBlockUserPayload> DeleteBlockUserAsync(
            [Service] IWriteService<BlockUser, CreateBlockUserDto, UpdateBlockUserDto, Guid> writeService,
            Guid key)
        {
            var result = await _mutationService.DeleteAsync(writeService, key);

            return result.Success
                ? new DeleteBlockUserSuccessPayload(result.Message)
                : new DeleteBlockUserFailurePayload(result.Message, result.Errors ?? []);
        }
    }
}
