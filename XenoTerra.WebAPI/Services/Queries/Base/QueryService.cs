using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
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

            var query = _readService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<TEntity>().AsQueryable();

            query = ModifyQueryForGetAll(query);

            return query;
        }

        public IQueryable<TEntity> GetByIdsQueryable(IEnumerable<TKey> keys, IResolverContext context)
        {
            if (keys is null || !keys.Any())
                throw new ArgumentNullException(nameof(keys), "The keys collection cannot be null or empty.");

            var selectedFields = GraphQLFieldProvider.GetSelectedFields(context);
            var query = _readService.FetchByIdsQueryable(keys, selectedFields) ?? Enumerable.Empty<TEntity>().AsQueryable();

            query = ModifyQueryForGetByIds(query);

            return query;
        }

        public IQueryable<TEntity> GetByIdQueryable(TKey key, IResolverContext context)
        {
            if (key is null || (EqualityComparer<TKey>.Default.Equals(key, default) && typeof(TKey) == typeof(Guid)))
                throw new ArgumentException("The key cannot be null or an empty GUID.", nameof(key));

            var selectedFields = GraphQLFieldProvider.GetSelectedFields(context);
            var query = _readService.FetchByIdQueryable(key, selectedFields) ?? Enumerable.Empty<TEntity>().AsQueryable();

            query = ModifyQueryForGetById(query);

            return query;
        }

        public virtual IQueryable<TEntity> ModifyQueryForGetAll(IQueryable<TEntity> query) => query;
        public virtual IQueryable<TEntity> ModifyQueryForGetByIds(IQueryable<TEntity> query) => query;
        public virtual IQueryable<TEntity> ModifyQueryForGetById(IQueryable<TEntity> query) => query;
    }
}
