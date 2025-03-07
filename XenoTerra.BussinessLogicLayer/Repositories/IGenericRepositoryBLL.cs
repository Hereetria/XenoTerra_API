

namespace XenoTerra.BussinessLogicLayer.Repositories
{
        public interface IGenericRepositoryBLL<TEntity, TResultDto, TResultWithRelationsDto, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TResultDto : class
        where TResultWithRelationsDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        Task<List<Guid>> GetAllIdsAsync();
        IQueryable<TResultDto> GetByIdsQuerable(IEnumerable<Guid> ids);
        Task<IEnumerable<TResultWithRelationsDto>> GetByIdsWithRelationsAsync(IEnumerable<Guid> ids, IEnumerable<string> selectedFields);
        Task<TResultDto> CreateAsync(TCreateDto createDto);

        Task<TResultDto> UpdateAsync(TUpdateDto updateDto);

        Task<bool> DeleteAsync(TKey id);
    }
}