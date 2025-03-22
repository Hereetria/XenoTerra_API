using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace XenoTerra.WebAPI.Services.Common.EntityMapping
{
    public interface IEntityFieldMapBuilder<TEntity, TDtoResult, TKey>
        where TEntity : class
        where TDtoResult : class
        where TKey : notnull
    {
        Dictionary<Type, (HashSet<TKey> NavigationIds, HashSet<string> SelectedFields)> Build(
            IEnumerable<TDtoResult> dtoList,
            IResolverContext context);
    }
}
