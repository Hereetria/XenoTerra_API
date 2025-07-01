using AutoMapper;
using FluentValidation;
using XenoTerra.BussinessLogicLayer.Exceptions.Domain;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryServices.Write.Own;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.StoryMutationServices
{
    public class StoryOwnMutationService(
        IStoryOwnWriteService writeService,
        IMapper mapper)
        : IStoryOwnMutationService
    {
        private readonly IStoryOwnWriteService _writeService = writeService;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateStoryOwnPayload> CreateAsync(CreateStoryOwnDto dto)
        {
            return await ExecuteSafelyAsync<ResultStoryOwnDto, CreateStoryOwnPayload>(
                async () =>
                {
                    var entity = await _writeService.CreateStoryAsync(dto);
                    return _mapper.Map<ResultStoryOwnDto>(entity);
                },
                "creating Story",
                "STORY_CREATE_ERROR"
            );
        }

        public async Task<DeleteStoryOwnPayload> DeleteAsync(Guid key)
        {
            return await ExecuteSafelyAsync<ResultStoryOwnDto, DeleteStoryOwnPayload>(
                async () =>
                {
                    var entity = await _writeService.DeleteStoryAsync(key);
                    return _mapper.Map<ResultStoryOwnDto>(entity);
                },
                "deleting Story",
                "STORY_DELETE_ERROR"
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
