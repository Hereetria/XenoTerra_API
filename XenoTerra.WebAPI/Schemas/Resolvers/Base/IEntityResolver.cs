using HotChocolate.Resolvers;

namespace XenoTerra.WebAPI.Schemas.Resolvers.Base
{
    public interface IEntityResolver<TEntity, TDtoResult, TKey>
        where TEntity : class
        where TDtoResult : class
        where TKey : notnull
    {
        Task PopulateRelatedFieldAsync(TDtoResult result, IResolverContext context);
        Task PopulateRelatedFieldsAsync(IEnumerable<TDtoResult> resultList, IResolverContext context);
    }
}
