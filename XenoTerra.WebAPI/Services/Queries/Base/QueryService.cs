﻿using HotChocolate.Resolvers;
using System.Linq.Expressions;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DataAccessLayer.Helpers;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.Services.Queries.Base
{
    public class QueryService<TEntity, TKey>(IReadService<TEntity, TKey> readService) : IQueryService<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        protected readonly IReadService<TEntity, TKey> _readService = readService;

        public IQueryable<TEntity> GetAllQueryable(
            IResolverContext context,
            Expression<Func<TEntity, bool>>? filter = null)
        {
            var selectedFields = GraphQLFieldProvider.GetSelectedFields(context).ToList();
            selectedFields = [.. EnsureForeignKeysForRelations(selectedFields, context)];

            ArgumentGuard.EnsureNotNullOrEmpty(selectedFields);

            var query = ExecuteSafely(() =>
            {
                var rawQuery = _readService.GetRawQueryable();

                if (filter is not null)
                    rawQuery = rawQuery.Where(filter);

                var baseQuery = rawQuery
                    .ApplyDefaultFiltering(context)
                    .ApplyDefaultSorting(context);

                baseQuery = _readService.FetchAllQueryable(baseQuery, selectedFields)
                    ?? Enumerable.Empty<TEntity>().AsQueryable();

                baseQuery = ModifyQueryForGetAll(baseQuery);

                return baseQuery;
            }) ?? Enumerable.Empty<TEntity>().AsQueryable();

            return query;
        }

        public IQueryable<TEntity> GetByIdsQueryable(
            IEnumerable<TKey> keys,
            IResolverContext context,
            Expression<Func<TEntity, bool>>? filter = null)
        {
            var selectedFields = GraphQLFieldProvider.GetSelectedFields(context);
            selectedFields = [.. EnsureForeignKeysForRelations(selectedFields, context)];

            ArgumentGuard.EnsureNotNullOrEmpty(selectedFields);

            var query = ExecuteSafely(() =>
            {
                var rawQuery = _readService.GetRawQueryable();

                // 🔥 Filtre varsa uygula
                if (filter is not null)
                    rawQuery = rawQuery.Where(filter);

                var baseQuery = rawQuery
                    .ApplyDefaultFiltering(context)
                    .ApplyDefaultSorting(context);

                baseQuery = _readService.FetchByIdsQueryable(baseQuery, keys, selectedFields)
                    ?? Enumerable.Empty<TEntity>().AsQueryable();

                baseQuery = ModifyQueryForGetByIds(baseQuery);

                return baseQuery;
            }) ?? Enumerable.Empty<TEntity>().AsQueryable();

            return query;
        }

        public IQueryable<TEntity> GetByIdQueryable(
            TKey key,
            IResolverContext context,
            Expression<Func<TEntity, bool>>? filter = null)
        {
            var selectedFields = GraphQLFieldProvider.GetSelectedFields(context);
            selectedFields = [.. EnsureForeignKeysForRelations(selectedFields, context)];

            ArgumentGuard.EnsureNotNullOrEmpty(selectedFields);

            var query = ExecuteSafely(() =>
            {
                var rawQuery = _readService.GetRawQueryable();

                if (filter is not null)
                    rawQuery = rawQuery.Where(filter);

                var baseQuery = _readService.FetchByIdQueryable(rawQuery, key, selectedFields)
                    ?? Enumerable.Empty<TEntity>().AsQueryable();

                return ModifyQueryForGetById(baseQuery);
            }) ?? Enumerable.Empty<TEntity>().AsQueryable();

            return query;
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
            catch (InvalidOperationException ex)
            {
                throw GraphQLExceptionFactory.Create(
                    "A filtering operation failed due to invalid operation.",
                    [ex.Message],
                    "INVALID_OPERATION");
            }
            catch (NotSupportedException ex)
            {
                throw GraphQLExceptionFactory.Create(
                    "An unsupported operation was used in the query.",
                    [ex.Message],
                    "UNSUPPORTED_OPERATION");
            }
            catch (InvalidCastException ex)
            {
                throw GraphQLExceptionFactory.Create(
                    "Failed to cast a filter value to the expected type.",
                    [ex.Message],
                    "INVALID_CAST");
            }
            catch (Exception ex)
            {
                throw GraphQLExceptionFactory.Create(
                    "An error occurred while executing the query.",
                    [ex.Message],
                    "QUERY_EXECUTION_ERROR");
            }
        }

        public static IEnumerable<string> EnsureForeignKeysForRelations(IEnumerable<string> selectedFields, IResolverContext context)
        {
            var relationalFields = GraphQLFieldProvider.GetRelationalFields(context);

            var dbContext = context.Service<AppDbContext>();
            var fieldSet = selectedFields.ToHashSet(StringComparer.OrdinalIgnoreCase);

            foreach (var field in relationalFields)
            {
                var foreignKeyProp = TypeProviders.GetForeignKeyProperty<TEntity>(dbContext, field)
                    ?? throw new InvalidOperationException($"Foreign key property not found for field: {field}");

                if (!fieldSet.Contains(foreignKeyProp.Name))
                {
                    fieldSet.Add(foreignKeyProp.Name);
                }
            }

            return fieldSet;
        }
    }
}
