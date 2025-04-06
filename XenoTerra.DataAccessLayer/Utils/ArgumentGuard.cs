using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DataAccessLayer.Utils
{
    public static class ArgumentGuard
    {
        public static void EnsureNotNull<TArgument>(TArgument value, string? nullMessage = null)
            where TArgument : class
        {
            string parameterName = nameof(value);
            if (value is null)
                throw new ArgumentNullException(parameterName, nullMessage ?? $"{parameterName} cannot be null.");
        }

        public static void EnsureNotNullOrEmpty<TArgument>(TArgument value, string? nullMessage = null, string? emptyMessage = null)
        {
            string parameterName = nameof(value);
            if (value is null)
                throw new ArgumentNullException(parameterName, nullMessage ?? $"{parameterName} cannot be null.");

            if (value is IEnumerable enumerable && !enumerable.Cast<object>().Any() ||
                value is Guid guid && guid == Guid.Empty)
            {
                throw new ArgumentException(emptyMessage ?? $"{parameterName} cannot be an empty", parameterName);
            }
        }


        public static void EnsureValidKey<TKey>(TKey key)
        {
            if (key is null || typeof(TKey) == typeof(Guid) && EqualityComparer<TKey>.Default.Equals(key, default))
            {
                throw new ArgumentException("The key cannot be null or an empty GUID.", nameof(key));
            }
        }
    }
}
