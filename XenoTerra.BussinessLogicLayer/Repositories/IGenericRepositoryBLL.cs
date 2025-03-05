

namespace XenoTerra.BussinessLogicLayer.Repositories
{
        public interface IGenericRepositoryBLL<TEntity, TResultDto, TResultById, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TResultDto : class
        where TResultById : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        Task<List<Guid>> GetAllIdsAsync();
        IQueryable<TEntity> GetByIdsQuerable(IEnumerable<Guid> ids);
        Task<TResultById> CreateAsync(TCreateDto createDto);

        Task<TResultById> UpdateAsync(TUpdateDto updateDto);

        Task<bool> DeleteAsync(TKey id);
    }
}