using System.Linq.Expressions;

namespace XenoTerra.DataAccessLayer.Utils
{
    public static class SelectorExpressionProvider
    {
        public static Expression<Func<TSource, TDestination>> GetSelectorExpression<TSource, TDestination>(
            IReadOnlyCollection<string> propertyNames)
            where TSource : class
            where TDestination : class, new()
        {
            var parameter = Expression.Parameter(typeof(TSource), "h");
            var bindings = new List<MemberBinding>();

            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();

            foreach (var propName in propertyNames)
            {
                var sourceProp = sourceProperties.FirstOrDefault(p => string.Equals(p.Name, propName, StringComparison.OrdinalIgnoreCase));
                var destinationProp = destinationProperties.FirstOrDefault(p => string.Equals(p.Name, propName, StringComparison.OrdinalIgnoreCase));

                if (destinationProp != null && sourceProp != null)
                {
                    var propertyExpression = Expression.Property(parameter, sourceProp);
                    var binding = Expression.Bind(destinationProp, propertyExpression);
                    bindings.Add(binding);
                }
            }

            var body = Expression.MemberInit(Expression.New(typeof(TDestination)), bindings);
            return Expression.Lambda<Func<TSource, TDestination>>(body, parameter);
        }
    }
}
