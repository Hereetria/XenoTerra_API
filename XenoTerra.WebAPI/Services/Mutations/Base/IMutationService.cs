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
        Task<TPayload> CreateAsync<TPayload>(
            IWriteService<TEntity, TCreateDto, TUpdateDto, TKey> writeService,
            TCreateDto createDto
        )
            where TPayload : Payload<TResultDto>, new();

        Task<TPayload> UpdateAsync<TPayload>(
            IWriteService<TEntity, TCreateDto, TUpdateDto, TKey> writeService,
            TUpdateDto updateDto,
            IEnumerable<string> modifiedFields
        )
            where TPayload : Payload<TResultDto>, new();

        Task<TPayload> DeleteAsync<TPayload>(
            IWriteService<TEntity, TCreateDto, TUpdateDto, TKey> writeService,
            TKey key
        )
            where TPayload : Payload<TResultDto>, new();
    }
}
