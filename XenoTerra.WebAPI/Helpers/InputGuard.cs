using System.Diagnostics.CodeAnalysis;

namespace XenoTerra.WebAPI.Helpers
{
    public static class InputGuard
    {
        public static void EnsureNotNull<TInput>([NotNull] TInput? input, string inputName)
            where TInput : class
        {
            if (input is null)
            {
                throw GraphQLExceptionFactory.Create(
                    $"{inputName} cannot be null.",
                    [$"{inputName} is required."],
                    "VALIDATION_ERROR");
            }
        }
    }
}
