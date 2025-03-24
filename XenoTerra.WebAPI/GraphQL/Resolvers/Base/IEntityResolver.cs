using HotChocolate.Resolvers;
using XenoTerra.DataAccessLayer.Contexts;

namespace XenoTerra.WebAPI.Schemas.Resolvers.Base
{
    public interface IEntityResolver<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        Task PopulateRelatedFieldAsync(TEntity entityResult, IResolverContext context);
        Task PopulateRelatedFieldsAsync(IEnumerable<TEntity> entityResultList, IResolverContext context);
    }
}
