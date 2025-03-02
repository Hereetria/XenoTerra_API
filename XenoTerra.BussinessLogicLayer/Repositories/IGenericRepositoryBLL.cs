

namespace XenoTerra.BussinessLogicLayer.Repositories
{
        public interface IGenericRepositoryBLL<TEntity, TResultDto, TResultById, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TResultDto : class
        where TResultById : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        IQueryable<TResultDto> GetAllQuerable();
        IQueryable<TResultById> GetByIdQuerable(TKey id);
        Task<TResultById> GetByIdAsync(TKey id);
        Task<TResultById> CreateAsync(TCreateDto createDto);

        Task<TResultById> UpdateAsync(TUpdateDto updateDto);

        Task<bool> DeleteAsync(TKey id);
    }
}