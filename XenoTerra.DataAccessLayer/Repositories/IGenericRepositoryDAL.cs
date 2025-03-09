
using System.Linq.Expressions;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.DataAccessLayer.Repositories
{
    
    public interface IGenericRepositoryDAL<TEntity, TResultDto, TResultWithRelationsDto, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TResultDto : class
        where TResultWithRelationsDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        Task<List<Guid>> TGetAllIdsAsync();
        IQueryable<TResultDto> TGetByIdsQuerable(IEnumerable<Guid> ids);
        Task<IEnumerable<TResultWithRelationsDto>> TGetByIdsWithRelationsAsync(IEnumerable<Guid> ids, IEnumerable<string> selectedFields);

        Task<TResultDto> TCreateAsync(TCreateDto createDto);

        Task<TResultDto> TUpdateAsync(TUpdateDto updateDto);

        Task<bool> TDeleteAsync(TKey key);

    }
}