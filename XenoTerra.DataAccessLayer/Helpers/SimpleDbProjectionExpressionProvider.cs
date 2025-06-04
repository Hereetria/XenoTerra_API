using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;

namespace XenoTerra.DataAccessLayer.Helpers
{
    public class SimpleDbProjectionExpressionProvider
    {
        public static Expression<Func<TEntity, TEntity>> CreateSelectorExpression<TEntity>(
            AppDbContext context,
            IEnumerable<string> selectedFields)
            where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            var bindings = new List<MemberBinding>();
            var selectedFieldsSet = new HashSet<string>(selectedFields, StringComparer.OrdinalIgnoreCase);

            var entityType = GetEntityType(context, typeof(TEntity));

            ProcessSelectedFields<TEntity>(entityType, parameter, selectedFieldsSet, bindings);

            var body = Expression.MemberInit(Expression.New(typeof(TEntity)), bindings);
            return Expression.Lambda<Func<TEntity, TEntity>>(body, parameter);
        }

        private static IEntityType GetEntityType(AppDbContext context, Type entityType)
        {
            return context.Model.FindEntityType(entityType)
                ?? throw new InvalidOperationException($"Entity metadata for {entityType.Name} could not be found.");
        }

        private static void ProcessSelectedFields<TEntity>(
            IEntityType entityType,
            ParameterExpression parameter,
            HashSet<string> selectedFields,
            List<MemberBinding> bindings)
            where TEntity : class
        {
            var fieldQueue = new Queue<string>(selectedFields);

            while (fieldQueue.Count > 0)
            {
                var field = fieldQueue.Dequeue();
                var entityProperty = FindPropertyIgnoreCase(typeof(TEntity), field);

                if (entityProperty != null)
                {
                    if (IsPrimitiveOrSimpleType(entityProperty.PropertyType))
                    {
                        bindings.Add(Expression.Bind(entityProperty, Expression.Property(parameter, entityProperty)));
                    }
                    continue;
                }

                var navigation = FindNavigationIgnoreCase(entityType, field);
                if (navigation != null)
                {
                    AddForeignKeyToQueue(navigation, selectedFields, fieldQueue);
                }
            }
        }

        private static void AddForeignKeyToQueue(INavigation navigation, HashSet<string> selectedFields, Queue<string> fieldQueue)
        {
            var foreignKey = navigation.ForeignKey.Properties.FirstOrDefault();
            if (foreignKey != null && selectedFields.Add(foreignKey.Name))
            {
                fieldQueue.Enqueue(foreignKey.Name);
            }
        }

        private static PropertyInfo? FindPropertyIgnoreCase(Type type, string propertyName)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                       .FirstOrDefault(p => string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));
        }

        private static INavigation? FindNavigationIgnoreCase(IEntityType entityType, string navigationName)
        {
            return entityType.GetNavigations()
                             .FirstOrDefault(n => string.Equals(n.Name, navigationName, StringComparison.OrdinalIgnoreCase));
        }

        private static bool IsPrimitiveOrSimpleType(Type type)
        {
            var underlyingType = Nullable.GetUnderlyingType(type) ?? type;

            return underlyingType.IsPrimitive ||
                   underlyingType == typeof(string) ||
                   underlyingType == typeof(Guid) ||
                   underlyingType == typeof(DateTime) ||
                   underlyingType == typeof(decimal) ||
                   underlyingType == typeof(float) ||
                   underlyingType == typeof(double) ||
                   underlyingType == typeof(long) ||
                   underlyingType == typeof(int);
        }

    }
}
