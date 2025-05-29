using System.Linq.Expressions;

namespace XenoTerra.WebAPI.Helpers
{
    public static class FilterExpressionHelper
    {
        public static Expression<Func<TEntity, bool>> BuildEqualsExpression<TEntity, TValue>(
            Expression<Func<TEntity, TValue>> selector,
            TValue value)
        {
            var param = selector.Parameters[0];
            var constant = Expression.Constant(value, typeof(TValue));
            var body = Expression.Equal(selector.Body, constant);
            return Expression.Lambda<Func<TEntity, bool>>(body, param);
        }

        public static Expression<Func<TEntity, bool>> BuildNotEqualsExpression<TEntity, TValue>(
            Expression<Func<TEntity, TValue>> selector,
            TValue value)
        {
            var param = selector.Parameters[0];
            var constant = Expression.Constant(value, typeof(TValue));
            var body = Expression.NotEqual(selector.Body, constant);
            return Expression.Lambda<Func<TEntity, bool>>(body, param);
        }

        public static Expression<Func<TEntity, bool>> BuildContainsExpression<TEntity, TValue>(
            Expression<Func<TEntity, TValue>> selector,
            IEnumerable<TValue> values)
        {
            var param = selector.Parameters[0];
            var body = selector.Body;

            var containsMethod = typeof(Enumerable)
                .GetMethods()
                .First(m => m.Name == nameof(Enumerable.Contains) && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(TValue));

            var constant = Expression.Constant(values.ToList());
            var call = Expression.Call(containsMethod, constant, body);

            return Expression.Lambda<Func<TEntity, bool>>(call, param);
        }

        public static Expression<Func<TEntity, bool>> BuildNotContainsExpression<TEntity, TValue>(
            Expression<Func<TEntity, TValue>> selector,
            IEnumerable<TValue> values)
        {
            var containsExpr = BuildContainsExpression(selector, values);
            var notBody = Expression.Not(containsExpr.Body);
            return Expression.Lambda<Func<TEntity, bool>>(notBody, containsExpr.Parameters[0]);
        }

        public static Expression<Func<TEntity, bool>> BuildContainsAndNotContainsExpression<TEntity, TValue>(
            Expression<Func<TEntity, TValue>> selector,
            IEnumerable<TValue> includes,
            IEnumerable<TValue> excludes)
        {
            var includeExpr = BuildContainsExpression(selector, includes);
            var excludeExpr = BuildNotContainsExpression(selector, excludes);
            var andExpr = Expression.AndAlso(includeExpr.Body, excludeExpr.Body);
            return Expression.Lambda<Func<TEntity, bool>>(andExpr, includeExpr.Parameters[0]);
        }

        public static Expression<Func<TEntity, bool>> BuildEqualsOrEqualsExpression<TEntity, TValue>(
            Expression<Func<TEntity, TValue>> leftSelector,
            Expression<Func<TEntity, TValue>> rightSelector,
            TValue value)
        {
            var param = Expression.Parameter(typeof(TEntity), "e");

            var left = ReplaceParameter(leftSelector.Body, leftSelector.Parameters[0], param);
            var right = ReplaceParameter(rightSelector.Body, rightSelector.Parameters[0], param);

            var constant = Expression.Constant(value, typeof(TValue));
            var orExpr = Expression.OrElse(Expression.Equal(left, constant), Expression.Equal(right, constant));

            return Expression.Lambda<Func<TEntity, bool>>(orExpr, param);
        }

        private static Expression ReplaceParameter(Expression body, ParameterExpression oldParam, ParameterExpression newParam)
        {
            return new ParameterReplacer(oldParam, newParam).Visit(body)!;
        }

        public static Expression<Func<T, bool>> And<T>(
            this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            var parameter = Expression.Parameter(typeof(T), "x");

            var leftVisitor = new ReplaceParameterVisitor(left.Parameters[0], parameter);
            var leftBody = leftVisitor.Visit(left.Body);

            var rightVisitor = new ReplaceParameterVisitor(right.Parameters[0], parameter);
            var rightBody = rightVisitor.Visit(right.Body);

            var body = Expression.AndAlso(leftBody!, rightBody!);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        public static Expression<Func<TEntity, bool>> BuildMultiEqualsOrExpression<TEntity, TValue>(
            IEnumerable<Expression<Func<TEntity, TValue>>> propertySelectors,
            TValue value)
            where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            Expression? combined = null;

            foreach (var selector in propertySelectors)
            {
                var replacedBody = ReplaceParameter(selector.Body, selector.Parameters[0], parameter);

                var constant = Expression.Constant(value, typeof(TValue));
                var equals = Expression.Equal(replacedBody, constant);

                combined = combined == null ? equals : Expression.OrElse(combined, equals);
            }

            return Expression.Lambda<Func<TEntity, bool>>(combined!, parameter);
        }

        public static Expression<Func<TEntity, bool>> BuildNestedContainsExpression<TEntity, TKey>(
            IEnumerable<Expression<Func<TEntity, TKey>>> propertySelectors,
            IEnumerable<TKey> allowedKeys)
            where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            Expression? combined = null;

            var containsMethod = typeof(List<TKey>)
                .GetMethod(nameof(List<TKey>.Contains), [typeof(TKey)])!;

            var allowedValues = allowedKeys.ToList();
            var valuesExpression = Expression.Constant(allowedValues);

            foreach (var selector in propertySelectors)
            {
                var replacedBody = ReplaceParameter(selector.Body, selector.Parameters[0], parameter);
                var containsCall = Expression.Call(valuesExpression, containsMethod, replacedBody);

                combined = combined == null ? containsCall : Expression.OrElse(combined, containsCall);
            }

            return Expression.Lambda<Func<TEntity, bool>>(combined!, parameter);
        }

        public static Expression<Func<TEntity, bool>> BuildMultiContainsAndExpression<TEntity, TKey>(
            IEnumerable<string> propertyNames,
            IEnumerable<TKey> allowedValues)
            where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var valuesList = allowedValues.ToList();

            if (valuesList.Count == 0)
                return _ => false;

            var containsMethod = typeof(List<TKey>)
                .GetMethod(nameof(List<TKey>.Contains), [typeof(TKey)])!;

            Expression? combined = null;

            foreach (var propertyName in propertyNames)
            {
                var property = Expression.Property(parameter, propertyName);
                var containsCall = Expression.Call(Expression.Constant(valuesList), containsMethod, property);

                combined = combined == null ? containsCall : Expression.AndAlso(combined, containsCall);
            }

            return Expression.Lambda<Func<TEntity, bool>>(combined!, parameter);
        }

        public static Expression<Func<TEntity, bool>> BuildMultiContainsOrExpression<TEntity, TKey>(
            IEnumerable<string> propertyNames,
            IEnumerable<TKey> allowedValues)
            where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var valuesList = allowedValues.ToList();

            if (valuesList.Count == 0)
                return _ => false;

            var containsMethod = typeof(List<TKey>)
                .GetMethod(nameof(List<TKey>.Contains), [typeof(TKey)])!;

            Expression? combined = null;

            foreach (var propertyName in propertyNames)
            {
                var property = Expression.Property(parameter, propertyName);
                var containsCall = Expression.Call(Expression.Constant(valuesList), containsMethod, property);

                combined = combined == null ? containsCall : Expression.OrElse(combined, containsCall);
            }

            return Expression.Lambda<Func<TEntity, bool>>(combined!, parameter);
        }


        private class ReplaceParameterVisitor(ParameterExpression oldParam, ParameterExpression newParam) : ExpressionVisitor
        {
            private readonly ParameterExpression _oldParam = oldParam;
            private readonly ParameterExpression _newParam = newParam;

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return node == _oldParam ? _newParam : base.VisitParameter(node);
            }
        }

        private class ParameterReplacer(ParameterExpression oldParam, ParameterExpression newParam) : ExpressionVisitor
        {
            private readonly ParameterExpression _oldParam = oldParam;
            private readonly ParameterExpression _newParam = newParam;

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return node == _oldParam ? _newParam : base.VisitParameter(node);
            }
        }
    }
}
