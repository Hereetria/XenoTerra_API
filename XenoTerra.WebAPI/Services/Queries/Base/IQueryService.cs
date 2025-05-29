using HotChocolate.Resolvers;
using System.Linq.Expressions;

namespace XenoTerra.WebAPI.Services.Queries.Base
{
    public interface IQueryService<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        IQueryable<TEntity> GetAllQueryable(
            IResolverContext context,
            Expression<Func<TEntity, bool>>? filter = null);

        IQueryable<TEntity> GetByIdsQueryable(
            IEnumerable<TKey> keys,
            IResolverContext context,
            Expression<Func<TEntity, bool>>? filter = null);

        IQueryable<TEntity> GetByIdQueryable(
            TKey key,
            IResolverContext context,
            Expression<Func<TEntity, bool>>? filter = null);

        IQueryable<TEntity> ModifyQueryForGetAll(IQueryable<TEntity> query);
        IQueryable<TEntity> ModifyQueryForGetByIds(IQueryable<TEntity> query);
        IQueryable<TEntity> ModifyQueryForGetById(IQueryable<TEntity> query);

    }
}
