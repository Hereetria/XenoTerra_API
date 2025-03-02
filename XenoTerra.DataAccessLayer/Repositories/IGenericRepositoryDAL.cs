
using System.Linq.Expressions;
namespace XenoTerra.DataAccessLayer.Repositories
{
    
    public interface IGenericRepositoryDAL<TEntity, TResultDto, TResultById,TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TResultDto : class
        where TResultById : class
        where TCreateDto : class
        where TUpdateDto : class
    {

        IQueryable<TResultDto> TGetAllQueryable();
        IQueryable<TResultById> TGetByIdQuerable(TKey id);

        Task<TResultById> TCreateAsync(TCreateDto createDto);

        Task<TResultById> TUpdateAsync(TUpdateDto updateDto);

        Task<bool> TDeleteAsync(TKey id);

        Task<TResultById> TGetByIdAsync(TKey id);

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