using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DataAccessLayer.Utils
{
    public static class SimpleProjectonExpressionProvider
    {
        public static Expression<Func<TEntity, TEntity>> CreateSelectorExpression<TEntity>(
            IEnumerable<string> selectedFields)
            where TEntity : class, new()
        {
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            var bindings = new List<MemberBinding>();

            var entityProperties = typeof(TEntity).GetProperties()
                .ToDictionary(p => p.Name.ToLower(CultureInfo.InvariantCulture), p => p);

            foreach (var field in selectedFields)
            {
                var normalizedField = field.ToLower(CultureInfo.InvariantCulture);
                if (entityProperties.TryGetValue(normalizedField, out var entityProperty))
                {
                    var propertyAccess = Expression.Property(parameter, entityProperty);
                    var binding = Expression.Bind(entityProperty, propertyAccess);
                    bindings.Add(binding);
                }
            }

            var newExpression = Expression.New(typeof(TEntity));
            var memberInit = Expression.MemberInit(newExpression, bindings);
            return Expression.Lambda<Func<TEntity, TEntity>>(memberInit, parameter);
        }
    }
}
