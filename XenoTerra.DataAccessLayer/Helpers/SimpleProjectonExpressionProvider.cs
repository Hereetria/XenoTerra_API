using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DataAccessLayer.Utils
{
    public static class SimpleProjectonExpressionProvider
    {
        public static Expression<Func<TEntity, TEntity>> CreateSelectorExpression<TEntity>(List<string> selectedFields)
            where TEntity : class
        {
            var entityParameter = Expression.Parameter(typeof(TEntity), "entity");

            var bindings = new List<MemberBinding>();
            var entityProperties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var field in selectedFields)
            {
                var entityProperty = entityProperties.FirstOrDefault(p =>
                    string.Equals(p.Name, field, StringComparison.OrdinalIgnoreCase));

                if (entityProperty != null && entityProperty.CanRead && entityProperty.CanWrite)
                {
                    var propertyAccess = Expression.Property(entityParameter, entityProperty);
                    var binding = Expression.Bind(entityProperty, propertyAccess);
                    bindings.Add(binding);
                }
            }

            var newEntity = Expression.New(typeof(TEntity));
            var body = Expression.MemberInit(newEntity, bindings);

            return Expression.Lambda<Func<TEntity, TEntity>>(body, entityParameter);
        }


    }
}
