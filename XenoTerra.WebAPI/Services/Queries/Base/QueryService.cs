using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Services.Queries.Base
{
    public class QueryService<TEntity, TKey>(IReadService<TEntity, TKey> readService) : IQueryService<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        protected readonly IReadService<TEntity, TKey> _readService = readService;

        public IQueryable<TEntity> GetAllQueryable(IResolverContext context)
        {
            var selectedFields = GraphQLFieldProvider.GetSelectedFields(context);
            if (selectedFields is null || selectedFields.Count == 0)
            {
                throw GraphQLExceptionFactory.Create(
                    "No fields were selected in the GraphQL query.",
                    ["You must select at least one field to query."],
                    "INVALID_SELECTION"
                );
            }

            var query = ExecuteSafely(() =>
                _readService.FetchAllQueryable(selectedFields)
            ) ?? Enumerable.Empty<TEntity>().AsQueryable();

            return ModifyQueryForGetAll(query);
        }

        public IQueryable<TEntity> GetByIdsQueryable(IEnumerable<TKey> keys, IResolverContext context)
        {
            var selectedFields = GraphQLFieldProvider.GetSelectedFields(context);
            ArgumentGuard.EnsureNotNullOrEmpty(selectedFields);

            var query = ExecuteSafely(() =>
                _readService.FetchByIdsQueryable(keys, selectedFields)
            ) ?? Enumerable.Empty<TEntity>().AsQueryable();

            return ModifyQueryForGetByIds(query);
        }

        public IQueryable<TEntity> GetByIdQueryable(TKey key, IResolverContext context)
        {
            var selectedFields = GraphQLFieldProvider.GetSelectedFields(context);
            if (selectedFields is null || selectedFields.Count == 0)
            {
                throw GraphQLExceptionFactory.Create(
                    "No fields were selected in the GraphQL query.",
                    ["You must select at least one field to query."],
                    "INVALID_SELECTION"
                );
            }

            var query = ExecuteSafely(() =>
                _readService.FetchByIdQueryable(key, selectedFields)
            ) ?? Enumerable.Empty<TEntity>().AsQueryable();

            return ModifyQueryForGetById(query);
        }

        public virtual IQueryable<TEntity> ModifyQueryForGetAll(IQueryable<TEntity> query) => query;
        public virtual IQueryable<TEntity> ModifyQueryForGetByIds(IQueryable<TEntity> query) => query;
        public virtual IQueryable<TEntity> ModifyQueryForGetById(IQueryable<TEntity> query) => query;

        private static TResult ExecuteSafely<TResult>(Func<TResult> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                throw GraphQLExceptionFactory.Create(
                    "An error occurred while executing the query.",
                    [ex.Message],
                    "QUERY_EXECUTION_ERROR"
                );
            }
        }
    }
}
