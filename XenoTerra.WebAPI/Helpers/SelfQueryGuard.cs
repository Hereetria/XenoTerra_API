using System.Linq.Expressions;

namespace XenoTerra.WebAPI.Helpers
{
    public static class SelfQueryGuard
    {
        public static Expression<Func<TEntity, bool>> CreateOwnershipFilter<TEntity>(
            Guid currentUserId,
            Expression<Func<TEntity, Guid>> ownerIdSelector)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");

            var member = (ownerIdSelector.Body as MemberExpression)
                         ?? ((UnaryExpression)ownerIdSelector.Body).Operand as MemberExpression;

            if (member == null)
                throw new ArgumentException("Invalid expression. Must be a direct property access.", nameof(ownerIdSelector));

            var left = Expression.Property(parameter, member.Member.Name);
            var right = Expression.Constant(currentUserId);

            var equalExpr = Expression.Equal(left, right);

            return Expression.Lambda<Func<TEntity, bool>>(equalExpr, parameter);
        }

        public static Expression<Func<TEntity, bool>> CreateNestedOwnershipFilter<TEntity>(
            Guid currentUserId,
            Expression<Func<TEntity, Guid>> navigationToOwnerId)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");

            var body = ReplaceParameter(navigationToOwnerId.Body, navigationToOwnerId.Parameters[0], parameter);

            var right = Expression.Constant(currentUserId);
            var equalExpr = Expression.Equal(body, right);

            return Expression.Lambda<Func<TEntity, bool>>(equalExpr, parameter);
        }

        private static Expression ReplaceParameter(Expression body, ParameterExpression oldParam, ParameterExpression newParam)
        {
            return new ParameterReplacer(oldParam, newParam).Visit(body)!;
        }

        private class ParameterReplacer : ExpressionVisitor
        {
            private readonly ParameterExpression _oldParam;
            private readonly ParameterExpression _newParam;

            public ParameterReplacer(ParameterExpression oldParam, ParameterExpression newParam)
            {
                _oldParam = oldParam;
                _newParam = newParam;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return node == _oldParam ? _newParam : base.VisitParameter(node);
            }
        }
    }
}