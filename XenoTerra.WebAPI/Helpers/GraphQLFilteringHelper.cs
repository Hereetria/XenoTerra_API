using HotChocolate.Language;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using System.Linq.Expressions;
using System.Reflection;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.Helpers
{
    public static class GraphQLFilteringHelper
    {
        public static IQueryable<T> ApplyDefaultFiltering<T>(this IQueryable<T> query, IResolverContext context)
        {
            var selectedFields = GraphQLFieldProvider.GetSelectedFields(context);

            if (context.ArgumentLiteral<IValueNode>("where") is not ObjectValueNode filterNode)
                return query;

            return ApplyFilterNode(query, filterNode, selectedFields);
        }

        private static IQueryable<T> ApplyFilterNode<T>(IQueryable<T> query, ObjectValueNode node, IReadOnlyCollection<string> selectedFields)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var expressionBody = BuildFilterExpression<T>(node, parameter, selectedFields);
            return expressionBody is null ? query : query.Where(Expression.Lambda<Func<T, bool>>(expressionBody, parameter));
        }

        private static Expression? BuildFilterExpression<T>(ObjectValueNode node, ParameterExpression parameter, IReadOnlyCollection<string> selectedFields)
        {
            Expression? finalExpr = null;

            foreach (var field in node.Fields)
            {
                if (!selectedFields.Contains(field.Name.Value, StringComparer.OrdinalIgnoreCase))
                {
                    selectedFields = selectedFields
                        .Concat([field.Name.Value])
                        .ToList()
                        .AsReadOnly();
                }

                if (field.Name.Value is "and" or "or")
                {
                    if (field.Value is not ListValueNode listNode)
                        throw new InvalidOperationException($"'{field.Name.Value}' expects a list of conditions.");

                    var subExpressions = listNode.Items
                        .OfType<ObjectValueNode>()
                        .Select(item => BuildFilterExpression<T>(item, parameter, selectedFields))
                        .Where(expr => expr is not null)
                        .Cast<Expression>()
                        .ToArray();

                    var combined = field.Name.Value switch
                    {
                        "and" => subExpressions.Aggregate(Expression.AndAlso),
                        "or" => subExpressions.Aggregate(Expression.OrElse),
                        _ => throw new NotSupportedException()
                    };

                    finalExpr = finalExpr is null ? combined : Expression.AndAlso(finalExpr, combined);
                    continue;
                }

                if (field.Value is not ObjectValueNode opNode) continue;

                var propertyName = field.Name.Value;
                var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                    ?? throw new InvalidOperationException($"Property '{propertyName}' not found on type '{typeof(T).Name}'");

                // ICollection filtre desteği
                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(propertyInfo.PropertyType) && propertyInfo.PropertyType != typeof(string))
                {
                    Expression? collectionExpr = null;

                    foreach (var op in opNode.Fields)
                    {
                        var method = op.Name.Value switch
                        {
                            "any" => nameof(Enumerable.Any),
                            "all" => nameof(Enumerable.All),
                            "none" => nameof(Enumerable.All), // sonra tersine çevireceğiz
                            "some" => nameof(Enumerable.Any),
                            _ => throw new NotSupportedException($"Unsupported collection operator '{op.Name.Value}'")
                        };

                        var collectionItemType = propertyInfo.PropertyType.GetGenericArguments().FirstOrDefault()
                            ?? throw new InvalidOperationException($"Cannot determine item type of collection property '{propertyName}'");

                        var subParam = Expression.Parameter(collectionItemType, "c");
                        var subExpr = BuildFilterExpressionSub(subParam, collectionItemType, op.Value as ObjectValueNode ?? throw new InvalidOperationException("Invalid collection filter node."));
                        var lambda = Expression.Lambda(subExpr, subParam);

                        var propAccess = Expression.Property(parameter, propertyInfo.Name);
                        Expression callExpr = Expression.Call(typeof(Enumerable), method, [collectionItemType], propAccess, lambda);

                        if (op.Name.Value == "none")
                            callExpr = Expression.Not(callExpr);

                        collectionExpr = collectionExpr is null ? callExpr : Expression.AndAlso(collectionExpr, callExpr);
                    }

                    if (collectionExpr is not null)
                        finalExpr = finalExpr is null ? collectionExpr : Expression.AndAlso(finalExpr, collectionExpr);

                    continue;
                }

                if (!selectedFields.Contains(propertyName))
                    throw new InvalidOperationException($"Filtering failed: '{propertyName}' is not part of the selected GraphQL fields.");

                Expression? expr = opNode.Fields.Any(f => f.Value is ObjectValueNode || f.Name.Value is "and" or "or")
                    ? BuildNestedExpression<T>(parameter, propertyName, opNode)
                    : BuildSimpleExpression<T>(parameter, propertyName, opNode);

                finalExpr = finalExpr is null ? expr : Expression.AndAlso(finalExpr, expr);
            }

            return finalExpr;
        }

        private static InvocationExpression BuildNestedExpression<T>(ParameterExpression parameter, string propertyPath, ObjectValueNode node)
        {
            var navigationProperty = typeof(T).GetProperty(propertyPath, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                ?? throw new InvalidOperationException($"Property '{propertyPath}' not found on type '{typeof(T).Name}'");

            var subParam = Expression.Property(parameter, navigationProperty.Name);
            var exprParam = Expression.Parameter(navigationProperty.PropertyType, "sub");
            var exprBody = BuildFilterExpressionSub(exprParam, navigationProperty.PropertyType, node);

            var predicate = Expression.Lambda(exprBody, exprParam);
            return Expression.Invoke(predicate, subParam);
        }

        private static Expression BuildFilterExpressionSub(ParameterExpression parameter, Type type, ObjectValueNode node)
        {
            Expression? finalExpr = null;

            foreach (var field in node.Fields)
            {
                if (field.Name.Value == "and")
                {
                    if (field.Value is not ListValueNode andList)
                        throw new InvalidOperationException("'and' expects a list.");

                    var andExprs = andList.Items
                        .OfType<ObjectValueNode>()
                        .Select(item => BuildFilterExpressionSub(parameter, type, item))
                        .ToArray();

                    var combinedAnd = andExprs.Aggregate(Expression.AndAlso);
                    finalExpr = finalExpr is null ? combinedAnd : Expression.AndAlso(finalExpr, combinedAnd);
                    continue;
                }

                if (field.Name.Value == "or")
                {
                    if (field.Value is not ListValueNode orList)
                        throw new InvalidOperationException("'or' expects a list.");

                    var orExprs = orList.Items
                        .OfType<ObjectValueNode>()
                        .Select(item =>
                        {
                            Expression? groupExpr = null;
                            foreach (var innerField in item.Fields)
                            {
                                var propInfo = type.GetProperty(innerField.Name.Value, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                                    ?? throw new InvalidOperationException($"Property '{innerField.Name.Value}' not found on type '{type.Name}'");

                                if (innerField.Value is not ObjectValueNode innerOps)
                                    continue;

                                var propExpr = Expression.Property(parameter, propInfo.Name);

                                foreach (var op in innerOps.Fields)
                                {
                                    var val = GetSingleValue(op.Value, propInfo.PropertyType);
                                    var opExpr = BuildComparison(op.Name.Value, propExpr, val, propInfo.PropertyType);
                                    groupExpr = groupExpr is null ? opExpr : Expression.OrElse(groupExpr, opExpr);
                                }
                            }
                            return groupExpr!;
                        })
                        .ToArray();


                    var combinedOr = orExprs.Aggregate(Expression.OrElse);
                    finalExpr = finalExpr is null ? combinedOr : Expression.AndAlso(finalExpr, combinedOr);
                    continue;
                }

                if (field.Value is not ObjectValueNode opNode) continue;

                var propertyInfo = type.GetProperty(field.Name.Value, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                    ?? throw new InvalidOperationException($"Property '{field.Name.Value}' not found on type '{type.Name}'");

                var propExpr = Expression.Property(parameter, propertyInfo.Name);

                foreach (var op in opNode.Fields)
                {
                    var value = GetSingleValue(op.Value, propertyInfo.PropertyType);
                    var body = BuildComparison(op.Name.Value, propExpr, value, propertyInfo.PropertyType);
                    finalExpr = finalExpr is null ? body : Expression.AndAlso(finalExpr, body);
                }
            }                

            return finalExpr ?? throw new InvalidOperationException("Invalid filter expression. No valid conditions found."); ;

        }

        private static Expression BuildSimpleExpression<T>(ParameterExpression parameter, string propertyName, ObjectValueNode opNode)
        {
            var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                ?? throw new InvalidOperationException($"Property '{propertyName}' not found on type '{typeof(T).Name}'");

            var propExpr = Expression.Property(parameter, propertyInfo.Name);
            Expression? result = null;

            foreach (var op in opNode.Fields)
            {
                var value = GetValue<T>(op.Value, propertyName);
                var comparison = BuildComparison(op.Name.Value, propExpr, value, propertyInfo.PropertyType);
                result = result is null ? comparison : Expression.AndAlso(result, comparison);
            }

            return result!;
        }

        private static Expression BuildComparison(string opName, Expression property, object? value, Type type)
        {
            return opName switch
            {
                "eq" => Expression.Equal(property, Expression.Constant(value, type)),
                "neq" => Expression.NotEqual(property, Expression.Constant(value, type)),
                "gt" => Expression.GreaterThan(property, Expression.Constant(value, type)),
                "lt" => Expression.LessThan(property, Expression.Constant(value, type)),
                "gte" => Expression.GreaterThanOrEqual(property, Expression.Constant(value, type)),
                "lte" => Expression.LessThanOrEqual(property, Expression.Constant(value, type)),
                "ngt" => Expression.LessThanOrEqual(property, Expression.Constant(value, type)),
                "ngte" => Expression.LessThan(property, Expression.Constant(value, type)),
                "nlt" => Expression.GreaterThanOrEqual(property, Expression.Constant(value, type)),
                "nlte" => Expression.GreaterThan(property, Expression.Constant(value, type)),
                "in" => BuildIn(property, value, type, negate: false),
                "nin" => BuildIn(property, value, type, negate: true),
                "contains" => BuildStringCall(property, "Contains", value, false),
                "ncontains" => BuildStringCall(property, "Contains", value, true),
                "startsWith" => BuildStringCall(property, "StartsWith", value, false),
                "nstartsWith" => BuildStringCall(property, "StartsWith", value, true),
                "endsWith" => BuildStringCall(property, "EndsWith", value, false),
                "nendsWith" => BuildStringCall(property, "EndsWith", value, true),
                _ => throw new NotSupportedException($"Unsupported operator '{opName}'")
            };
        }

        private static Expression BuildIn(Expression property, object? value, Type propertyType, bool negate)
        {
            if (value is not Array array)
                throw new InvalidOperationException("'in'/'nin' operator requires an array");

            var constants = array.Cast<object?>()
                .Select(v => Expression.Constant(v, propertyType));

            var arrayExpr = Expression.NewArrayInit(propertyType, constants);
            var containsCall = Expression.Call(typeof(Enumerable), nameof(Enumerable.Contains), [propertyType], arrayExpr, property);

            return negate ? Expression.Not(containsCall) : containsCall;
        }

        private static Expression BuildStringCall(Expression property, string methodName, object? value, bool negate)
        {
            if (property.Type != typeof(string))
                throw new InvalidOperationException($"'{methodName}' operator only valid for string fields");

            var method = typeof(string).GetMethod(methodName, [typeof(string)])
                ?? throw new InvalidOperationException($"Method '{methodName}' not found on type 'String'");

            var call = Expression.Call(property, method, Expression.Constant(value, typeof(string)));
            return negate ? Expression.Not(call) : call;
        }


        private static object? GetValue<T>(IValueNode node, string propertyName)
        {
            var prop = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                ?? throw new InvalidOperationException($"Property '{propertyName}' not found on type '{typeof(T).Name}'");

            var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

            return node switch
            {
                NullValueNode => null,
                StringValueNode s => ParseString(s.Value, targetType),
                IntValueNode i => Convert.ChangeType(i.ToInt32(), targetType),
                FloatValueNode f => Convert.ChangeType(f.ToDouble(), targetType),
                BooleanValueNode b => Convert.ChangeType(b.Value, targetType),
                ListValueNode l => l.Items.Select(item => GetSingleValue(item, targetType)).ToArray(),
                _ => throw new NotSupportedException($"Unsupported value type '{node.Kind}' for field '{propertyName}'")
            };
        }

        private static object? GetSingleValue(IValueNode node, Type targetType) => node switch
        {
            NullValueNode => null,
            StringValueNode s => ParseString(s.Value, targetType),
            IntValueNode i => Convert.ChangeType(i.ToInt32(), targetType),
            FloatValueNode f => Convert.ChangeType(f.ToDouble(), targetType),
            BooleanValueNode b => Convert.ChangeType(b.Value, targetType),
            _ => throw new NotSupportedException($"Unsupported value type '{node.Kind}' in list for type '{targetType.Name}'")
        };

        private static object ParseString(string value, Type targetType)
        {
            try
            {
                return targetType switch
                {
                    var t when t == typeof(Guid) => Guid.Parse(value),
                    var t when t == typeof(DateTime) => DateTime.Parse(value),
                    var t when t.IsEnum => Enum.Parse(t, value),
                    _ => Convert.ChangeType(value, targetType)
                };
            }
            catch (Exception ex)
            {
                throw new InvalidCastException($"Cannot convert value '{value}' to type '{targetType.Name}': {ex.Message}");
            }
        }
    }
}
