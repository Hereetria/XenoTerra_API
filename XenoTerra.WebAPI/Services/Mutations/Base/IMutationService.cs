using HotChocolate.Execution;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Payloads;

namespace XenoTerra.WebAPI.Services.Mutations.Base
{
    public interface IMutationService<TEntity, TResultDto, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TResultDto : class
        where TCreateDto : class
        where TUpdateDto : class
        where TKey : notnull
    {
        Task<OperationResult<TResultDto>> CreateAsync(
            IWriteService<TEntity, TCreateDto, TUpdateDto, TKey> writeService,
            TCreateDto? input);

        Task<OperationResult<TResultDto>> UpdateAsync(
            IWriteService<TEntity, TCreateDto, TUpdateDto, TKey> writeService,
            TUpdateDto? input);

        Task<OperationResult<object>> DeleteAsync(
            IWriteService<TEntity, TCreateDto, TUpdateDto, TKey> writeService,
            TKey key);
    }
}
