using HotChocolate.Resolvers;

namespace XenoTerra.WebAPI.Schemas.Resolvers.Base
{
    public interface IEntityResolver<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        Task PopulateRelatedFieldAsync(TEntity result, IResolverContext context);
        Task PopulateRelatedFieldsAsync(IEnumerable<TEntity> resultList, IResolverContext context);
    }
}
