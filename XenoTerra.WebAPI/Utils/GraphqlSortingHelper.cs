using HotChocolate.Language;
using HotChocolate.Resolvers;
using System.Linq.Expressions;
using System.Reflection;

namespace XenoTerra.WebAPI.Utils
{
    public static class GraphQLSortingHelper
    {
        public static IQueryable<T> ApplyDefaultSorting<T>(this IQueryable<T> query, IResolverContext context)
        {
            if (context.ArgumentLiteral<IValueNode>("order") is not ListValueNode orderList || !orderList.Items.Any())
                return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            bool isFirst = true;

            foreach (var item in orderList.Items.OfType<ObjectValueNode>())
            {
                if (item.Fields.Count != 1) continue;

                var field = item.Fields[0];
                var (lambda, propertyType, direction) = BuildSorting(field, typeof(T), parameter);

                var methodName = (isFirst ? "OrderBy" : "ThenBy") + (direction == "DESC" ? "Descending" : "");

                query = typeof(Queryable)
                    .GetMethods()
                    .Where(m => m.Name == methodName && m.GetParameters().Length == 2)
                    .Single()
                    .MakeGenericMethod(typeof(T), propertyType)
                    .Invoke(null, [query, lambda]) as IQueryable<T>
                    ?? throw new InvalidOperationException($"Failed to apply sorting by '{field.Name.Value}'");

                isFirst = false;
            }

            return query;
        }


        private static (LambdaExpression Lambda, Type PropertyType, string Direction) BuildSorting(ObjectFieldNode field, Type rootType, ParameterExpression parameter)
        {
            var path = new List<string>();
            string? direction;
            Type currentType = rootType;

            IValueNode? currentNode = field.Value;
            path.Add(field.Name.Value);

            while (currentNode is ObjectValueNode objectNode)
            {
                if (objectNode.Fields.Count != 1)
                    throw new InvalidOperationException("Nested sort objects must have exactly one field.");

                var nestedField = objectNode.Fields[0];
                path.Add(nestedField.Name.Value);
                currentNode = nestedField.Value;
            }

            if (currentNode is not EnumValueNode directionNode)
                throw new InvalidOperationException("Final sort value must be a sort direction (ASC/DESC).");

            direction = directionNode.Value.ToUpperInvariant();

            Expression body = parameter;
            foreach (var segment in path)
            {
                var prop = currentType.GetProperty(segment, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                    ?? throw new InvalidOperationException($"Property '{segment}' not found on type '{currentType.Name}'");
                body = Expression.Property(body, prop);
                currentType = prop.PropertyType;
            }

            var lambda = Expression.Lambda(body, parameter);
            return (lambda, currentType, direction);
        }
    }
}
