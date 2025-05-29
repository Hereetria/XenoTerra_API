using System.Linq.Expressions;

namespace XenoTerra.WebAPI.Helpers
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> Or<T>(
            this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var left = ReplaceParameter(expr1.Body, expr1.Parameters[0], parameter);
            var right = ReplaceParameter(expr2.Body, expr2.Parameters[0], parameter);

            var orElse = Expression.OrElse(left, right);
            return Expression.Lambda<Func<T, bool>>(orElse, parameter);
        }

        private static Expression ReplaceParameter(
            Expression expression,
            ParameterExpression toReplace,
            ParameterExpression replacement)
        {
            return new ParameterReplacer(toReplace, replacement).Visit(expression)!;
        }

        private class ParameterReplacer(ParameterExpression from, ParameterExpression to) : ExpressionVisitor
        {
            private readonly ParameterExpression _from = from;
            private readonly ParameterExpression _to = to;

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return node == _from ? _to : base.VisitParameter(node);
            }
        }
    }
}
