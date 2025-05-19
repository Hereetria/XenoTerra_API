using System.Linq.Expressions;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;

namespace XenoTerra.WebAPI.Helpers
{
    public static class EntityReadHelper
    {
        public static TEntity FetchEntityWithSelectedFieldsOrThrow<TEntity, TKey>(
            IReadService<TEntity, TKey> readService,
            TKey id,
            params Expression<Func<TEntity, object>>[] selectedProperties)
            where TEntity : class
            where TKey : notnull
        {
            var rawQuery = readService.GetRawQueryable();

            var selectedFields = selectedProperties
                .Select(expr => GetPropertyName(expr))
                .ToList();

            var entity = readService
                .FetchByIdQueryable(rawQuery, id, selectedFields)
                .FirstOrDefault();

            if (entity is null)
            {
                var entityName = typeof(TEntity).Name;
                throw GraphQLExceptionFactory.Create(
                    $"{entityName} not found.",
                    [$"The specified {entityName} with ID '{id}' was not found."],
                    "NOT_FOUND");
            }

            return entity;
        }

        private static string GetPropertyName<TEntity>(Expression<Func<TEntity, object>> expression)
        {
            return expression.Body switch
            {
                MemberExpression m => m.Member.Name,
                UnaryExpression u when u.Operand is MemberExpression m => m.Member.Name,
                _ => throw new InvalidOperationException("Invalid expression format.")
            };
        }
    }
}