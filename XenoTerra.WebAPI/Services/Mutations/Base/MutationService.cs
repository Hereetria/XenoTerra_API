using AutoMapper;
using FluentValidation;
using GreenDonut;
using System.IdentityModel.Tokens.Jwt;
using XenoTerra.BussinessLogicLayer.Exceptions.Domain;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Payloads;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Services.Mutations.Base
{
    public class MutationService<TEntity, TResultDto, TCreateDto, TUpdateDto, TKey>(IMapper mapper)
        : IMutationService<TEntity, TResultDto, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TResultDto : class
        where TCreateDto : class
        where TUpdateDto : class
        where TKey : notnull
    {
        private static string EntityName => typeof(TEntity).Name;
        protected readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<TPayload> CreateAsync<TPayload>(
            IWriteService<TEntity, TCreateDto, TUpdateDto, TKey> writeService,
            TCreateDto createDto
        )
            where TPayload : Payload<TResultDto>, new()
        {
            await BeforeCreateAsync(createDto);

            return await ExecuteSafelyAsync<TPayload>(
                () => writeService.CreateAsync(createDto),
                "created",
                CustomizeCreateResult
            );
        }


        public async Task<TPayload> UpdateAsync<TPayload>(
            IWriteService<TEntity, TCreateDto, TUpdateDto, TKey> writeService,
            TUpdateDto updateDto,
            IEnumerable<string> modifiedFields
        )
            where TPayload : Payload<TResultDto>, new()
        {
            await BeforeUpdateAsync(updateDto);

            return await ExecuteSafelyAsync<TPayload>(
                () => writeService.UpdateAsync(updateDto, modifiedFields),
                "updated",
                CustomizeUpdateResult
            );
        }

        public async Task<TPayload> DeleteAsync<TPayload>(
            IWriteService<TEntity, TCreateDto, TUpdateDto, TKey> writeService,
            TKey key
        )
            where TPayload : Payload<TResultDto>, new()
        {
            return await ExecuteSafelyAsync<TPayload>(
                () => writeService.DeleteAsync(key),
                "deleted"
            );
        }

        private async Task<TPayload> ExecuteSafelyAsync<TPayload>(
            Func<Task<TEntity>> operation,
            string action,
            Action<TResultDto>? customize = null
        )
            where TPayload : Payload<TResultDto>, new()
        {
            try
            {
                var entity = await operation();
                var resultDto = _mapper.Map<TResultDto>(entity);

                customize?.Invoke(resultDto);

                return Payload<TResultDto>.FromSuccess<TPayload>(
                    $"{EntityName} {action} successfully",
                    resultDto
                );
            }
            catch (ForeignKeyReferenceNotFoundException ex)
            {
                return Payload<TResultDto>.FromFailure<TPayload>(
                    $"{EntityName} {action} failed due to foreign key constraint.",
                    [$"{ex.PropertyName} refers to a non-existing {ex.RelatedEntityName}."]
                );
            }
            catch (ValidationException ex)
            {
                return Payload<TResultDto>.FromFailure<TPayload>(
                    $"{EntityName} validation failed",
                    ExtractValidationMessages(ex)
                );
            }
            catch (System.Collections.Generic.KeyNotFoundException ex)
            {
                return Payload<TResultDto>.FromFailure<TPayload>(
                    $"The requested {EntityName} could not be found.",
                    [ex.Message]
                );
            }
            catch (Exception ex)
            {
                throw GraphQLExceptionFactory.Create(
                    $"An unexpected error occurred while {action} {EntityName.ToLowerInvariant()}.",
                    [ex.Message],
                    "MUTATION_EXECUTION_ERROR"
                );
            }
        }



        protected virtual Task BeforeCreateAsync(TCreateDto dto) => Task.CompletedTask;
        protected virtual Task AfterCreateAsync(TEntity entity) => Task.CompletedTask;
        protected virtual void CustomizeCreateResult(TResultDto result) { }

        protected virtual Task BeforeUpdateAsync(TUpdateDto dto) => Task.CompletedTask;
        protected virtual Task AfterUpdateAsync(TEntity entity) => Task.CompletedTask;
        protected virtual void CustomizeUpdateResult(TResultDto result) { }

        private static List<string> ExtractValidationMessages(ValidationException ex) =>
            [.. ex.Errors.Select(e => e.ErrorMessage)];
    }
}
