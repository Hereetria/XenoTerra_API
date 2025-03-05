
using System.Linq.Expressions;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.DataAccessLayer.Repositories
{
    
    public interface IGenericRepositoryDAL<TEntity, TResultDto, TResultById,TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TResultDto : class
        where TResultById : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        Task<List<Guid>> TGetAllIdsAsync();
        IQueryable<TEntity> TGetByIdsQuerable(IEnumerable<Guid> ids);

        Task<TResultById> TCreateAsync(TCreateDto createDto);

        Task<TResultById> TUpdateAsync(TUpdateDto updateDto);

        Task<bool> TDeleteAsync(TKey id);

        Task<List<TResultQueryDto>> TGetEntitiesByQueryAsync<TResultQueryDto>(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> query)
            where TResultQueryDto : class;

        Task<TResultQueryDto?> TGetEntityByQueryAsync<TResultQueryDto>(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> query)
            where TResultQueryDto : class;

        Task<List<TResultQueryDto>> TGetSelectedEntitiesByQueryAsync<TResultQueryDto, TResultEntity>(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> query,
            Expression<Func<TEntity, TResultEntity>> selectExpression)
            where TResultQueryDto : class
            where TResultEntity : class;
    }
}