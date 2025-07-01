using AutoMapper;
using FluentValidation;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingServices.Write.Own;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserSettingMutationServices
{
    public class UserSettingOwnMutationService(
        IUserSettingOwnWriteService writeService,
        IMapper mapper)
        : IUserSettingOwnMutationService
    {
        private readonly IUserSettingOwnWriteService _writeService = writeService;
        private readonly IMapper _mapper = mapper;

        public async Task<UpdateUserSettingOwnPayload> UpdateAsync(UpdateUserSettingOwnDto dto, IEnumerable<string> modifiedFields)
        {
            return await ExecuteSafelyAsync<ResultUserSettingOwnDto, UpdateUserSettingOwnPayload>(
                async () =>
                {
                    var entity = await _writeService.UpdateUserSettingAsync(dto, modifiedFields);
                    return _mapper.Map<ResultUserSettingOwnDto>(entity);
                },
                "updating UserSetting",
                "USER_SETTING_UPDATE_ERROR"
            );
        }

        public async Task<DeleteUserSettingOwnPayload> DeleteAsync(Guid key)
        {
            return await ExecuteSafelyAsync<ResultUserSettingOwnDto, DeleteUserSettingOwnPayload>(
                async () =>
                {
                    var entity = await _writeService.DeleteUserSettingAsync(key);
                    return _mapper.Map<ResultUserSettingOwnDto>(entity);
                },
                "deleting UserSetting",
                "USER_SETTING_DELETE_ERROR"
            );
        }

        private async Task<TPayload> ExecuteSafelyAsync<TResultDto, TPayload>(
            Func<Task<TResultDto>> operation,
            string actionDescription,
            string errorCode)
            where TResultDto : class
            where TPayload : Payload<TResultDto>, new()
        {
            try
            {
                var result = await operation();
                return Payload<TResultDto>.FromSuccess<TPayload>($"{actionDescription} succeeded.", result);
            }
            catch (ValidationException ex)
            {
                return Payload<TResultDto>.FromFailure<TPayload>($"{actionDescription} failed due to validation error.", ExtractValidationMessages(ex));
            }
            catch (GreenDonut.KeyNotFoundException ex)
            {
                return Payload<TResultDto>.FromFailure<TPayload>($"{actionDescription} failed. Entity not found.", [ex.Message]);
            }
            catch (Exception ex)
            {
                throw GraphQLExceptionFactory.Create(
                    $"An unexpected error occurred while {actionDescription}.",
                    [ex.Message],
                    errorCode
                );
            }
        }

        private static List<string> ExtractValidationMessages(ValidationException ex) =>
            [.. ex.Errors.Select(e => e.ErrorMessage)];
    }
}
