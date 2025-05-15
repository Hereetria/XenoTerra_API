using FluentValidation;

namespace XenoTerra.WebAPI.Helpers
{
    public static class ValidationGuard
    {
        public static async Task ValidateOrThrowAsync<T>(IValidator<T> validator, T instance)
            where T : class
        {
            var result = await validator.ValidateAsync(instance);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw GraphQLExceptionFactory.Create(
                    "Validation failed.",
                    errors,
                    "VALIDATION_ERROR");
            }
        }
    }
}
