using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;

namespace XenoTerra.DataAccessLayer.Utils
{
    public static class ReleatedProjectionExpressionProvider
    {
        public static Expression<Func<TEntity, TDtoResult>> CreateSelectorExpression<TEntity, TDtoResult>(
            AppDbContext context,
            IEnumerable<string> selectedFields)
            where TEntity : class
            where TDtoResult : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            var bindings = new List<MemberBinding>();

            var selectedFieldsSet = new HashSet<string>(selectedFields, StringComparer.OrdinalIgnoreCase);
            var fieldQueue = new Queue<string>(selectedFieldsSet);

            var entityType = context.Model.FindEntityType(typeof(TEntity))
                             ?? throw new InvalidOperationException($"Entity metadata for {typeof(TEntity).Name} could not be found.");

            while (fieldQueue.Count > 0)
            {
                var field = fieldQueue.Dequeue();
                var entityProperty = FindPropertyIgnoreCase(typeof(TEntity), field);
                var dtoProperty = FindPropertyIgnoreCase(typeof(TDtoResult), field);

                if (entityProperty == null || dtoProperty == null)
                    continue;

                if (IsPrimitiveOrSimpleType(entityProperty.PropertyType) && dtoProperty.PropertyType == entityProperty.PropertyType)
                {
                    bindings.Add(Expression.Bind(dtoProperty, Expression.Property(parameter, entityProperty)));
                    continue;
                }

                var navigation = FindNavigationIgnoreCase(entityType, field);
                if (navigation != null)
                {
                    var foreignKey = navigation.ForeignKey.Properties.FirstOrDefault();
                    if (foreignKey != null && !selectedFieldsSet.Contains(foreignKey.Name))
                    {
                        fieldQueue.Enqueue(foreignKey.Name);
                        selectedFieldsSet.Add(foreignKey.Name);
                    }
                }
            }

            var body = Expression.MemberInit(Expression.New(typeof(TDtoResult)), bindings);
            return Expression.Lambda<Func<TEntity, TDtoResult>>(body, parameter);
        }

        private static PropertyInfo? FindPropertyIgnoreCase(Type type, string propertyName)
        {
            return type.GetProperties()
                       .FirstOrDefault(p => string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));
        }

        private static INavigation? FindNavigationIgnoreCase(IEntityType entityType, string navigationName)
        {
            return entityType.GetNavigations()
                             .FirstOrDefault(n => string.Equals(n.Name, navigationName, StringComparison.OrdinalIgnoreCase));
        }

        private static bool IsPrimitiveOrSimpleType(Type type)
        {
            return type.IsPrimitive ||
                   type == typeof(string) ||
                   type == typeof(Guid) ||
                   type == typeof(DateTime) ||
                   type == typeof(decimal) ||
                   type == typeof(float) ||
                   type == typeof(double) ||
                   type == typeof(long) ||
                   type == typeof(int);
        }
    }
}
