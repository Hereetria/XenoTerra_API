using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using XenoTerra.DataAccessLayer.Contexts;

namespace XenoTerra.WebAPI.Services.Common.EntityMapping
{
    public interface IEntityFieldMapBuilder<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        Dictionary<Type, (HashSet<TKey> NavigationIds, HashSet<string> SelectedFields)> Build(
            IEnumerable<TEntity> entityList,
            IResolverContext context,
            AppDbContext dbContext);
    }
}
