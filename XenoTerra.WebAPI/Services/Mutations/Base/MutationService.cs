using AutoMapper;
using FluentValidation;
using GreenDonut;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Payloads;

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

        public async Task<OperationResult<TResultDto>> CreateAsync(
            IWriteService<TEntity, TCreateDto, TUpdateDto, TKey> writeService,
            TCreateDto? input)
        {
            if (input is null)
            {
                return OperationResult<TResultDto>.FromFailure(
                    "Input cannot be null",
                    ["Create DTO is required."]
                );
            }

            try
            {
                await BeforeCreateAsync(input);
                var entity = await writeService.CreateAsync(input);
                await AfterCreateAsync(entity);

                var resultDto = _mapper.Map<TResultDto>(entity);
                CustomizeCreateResult(resultDto);

                return OperationResult<TResultDto>.FromSuccess(
                    $"{EntityName} created successfully",
                    resultDto
                );
            }
            catch (ValidationException ex)
            {
                return OperationResult<TResultDto>.FromFailure(
                    $"{EntityName} validation failed",
                    ExtractValidationMessages(ex)
                );
            }
            catch (Exception ex)
            {
                return OperationResult<TResultDto>.FromFailure(
                    $"An error occurred while creating {EntityName}",
                    [ex.Message]
                );
            }
        }

        public async Task<OperationResult<TResultDto>> UpdateAsync(
            IWriteService<TEntity, TCreateDto, TUpdateDto, TKey> writeService,
            TUpdateDto? input)
        {
            if (input is null)
            {
                return OperationResult<TResultDto>.FromFailure(
                    "Input cannot be null",
                    ["Update DTO is required."]
                );
            }

            try
            {
                await BeforeUpdateAsync(input);
                var entity = await writeService.UpdateAsync(input);
                await AfterUpdateAsync(entity);

                var resultDto = _mapper.Map<TResultDto>(entity);
                CustomizeUpdateResult(resultDto);

                return OperationResult<TResultDto>.FromSuccess(
                    $"{EntityName} updated successfully",
                    resultDto
                );
            }
            catch (ValidationException ex)
            {
                return OperationResult<TResultDto>.FromFailure(
                    $"{EntityName} validation failed",
                    ExtractValidationMessages(ex)
                );
            }
            catch (Exception ex)
            {
                return OperationResult<TResultDto>.FromFailure(
                    $"An error occurred while updating {EntityName}",
                    [ex.Message]
                );
            }
        }

        public async Task<OperationResult<object>> DeleteAsync(
            IWriteService<TEntity, TCreateDto, TUpdateDto, TKey> writeService,
            TKey key)
        {
            if (key is null || EqualityComparer<TKey>.Default.Equals(key, default))
            {
                return OperationResult<object>.FromFailure(
                    "Invalid ID: ID cannot be empty.",
                    ["ID is required."]
                );
            }

            try
            {
                var success = await writeService.DeleteAsync(key);
                if (!success)
                {
                    return OperationResult<object>.FromFailure(
                        $"No {EntityName} found with given ID",
                        []
                    );
                }

                return OperationResult<object>.FromSuccess(
                    $"{EntityName} deleted successfully"
                );
            }
            catch (Exception ex)
            {
                return OperationResult<object>.FromFailure(
                    $"An error occurred while deleting {EntityName}",
                    [ex.Message]
                );
            }
        }

        protected virtual Task BeforeCreateAsync(TCreateDto input) => Task.CompletedTask;
        protected virtual Task AfterCreateAsync(TEntity entity) => Task.CompletedTask;
        protected virtual void CustomizeCreateResult(TResultDto result) { }

        protected virtual Task BeforeUpdateAsync(TUpdateDto input) => Task.CompletedTask;
        protected virtual Task AfterUpdateAsync(TEntity entity) => Task.CompletedTask;
        protected virtual void CustomizeUpdateResult(TResultDto result) { }

        protected static List<string> ExtractValidationMessages(ValidationException ex) =>
            [.. ex.Errors.Select(e => e.ErrorMessage)];
    }
}
