using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Reflection;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityAssignment;
using XenoTerra.WebAPI.Services.Common.EntityMapping;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Base
{
    public class EntityResolver<TEntity, TKey>(IEntityFieldMapBuilder<TEntity, TKey> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : IEntityResolver<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        private readonly IEntityFieldMapBuilder<TEntity, TKey> _entityFieldMapBuilder = entityFieldMapBuilder;
        private readonly IDataLoaderInvoker _dataLoaderInvoker = dataLoaderInvoker;

        public async Task PopulateRelatedFieldAsync(TEntity entityResult, IResolverContext context)
        {
            await PopulateRelatedFieldsAsync(Enumerable.Repeat(entityResult, 1), context);
        }


        public async Task PopulateRelatedFieldsAsync(
            IEnumerable<TEntity> entityResultList,
            IResolverContext context)
        {
            var dbContext = context.Services.GetRequiredService<AppDbContext>();
            var entityMaps = _entityFieldMapBuilder.Build(entityResultList, context, dbContext);

            foreach (var entry in entityMaps)
            {
                var entityType = entry.Key;
                var (entityIds, selectedFields) = entry.Value;
                var entityIdsList = entityIds?.Cast<object>().ToList() ?? [];

                var resultsDict = await _dataLoaderInvoker.InvokeLoadAsync(entityType, dbContext, entityIdsList, [.. selectedFields])
                    ?? throw new InvalidOperationException("InvokeLoadAsync returned null.");

                var resultsDictType = resultsDict.GetType();

                if (!resultsDictType.IsGenericType || resultsDictType.GetGenericTypeDefinition() != typeof(Dictionary<,>))
                {
                    throw new InvalidOperationException($"InvokeGenericLoadAsync did not return a valid Dictionary<TKey, TValue>. Found: {resultsDictType}");
                }

                var genericArguments = resultsDictType.GetGenericArguments();
                var relatedEntityKeyType = genericArguments[0];
                var relatedEntityType = genericArguments[1];

                var assignmentServiceType = typeof(EntityAssignmentService<,,>)
                    .MakeGenericType(typeof(TEntity), relatedEntityType, relatedEntityKeyType);

                var assignmentService = Activator.CreateInstance(assignmentServiceType)
                    ?? throw new InvalidOperationException("EntityAssignmentService instance could not be created.");

                var assignMethod = assignmentServiceType.GetMethod("AssignRelatedEntities")
                    ?? throw new InvalidOperationException("AssignRelatedEntities method not found.");

                var entityResultListMaterialized = entityResultList.ToList();
                assignMethod.Invoke(assignmentService, [dbContext, entityResultListMaterialized, resultsDict]);
            }
        }
    }
}
