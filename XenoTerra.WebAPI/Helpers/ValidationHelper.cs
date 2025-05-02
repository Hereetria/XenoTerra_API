namespace XenoTerra.WebAPI.Helpers
{
    public static class ValidationHelper
    {
        public static bool BeValidGuid(string? id) =>
            !string.IsNullOrWhiteSpace(id) && Guid.TryParse(id, out _);

        public static bool BeValidDate(string? date) =>
            !string.IsNullOrWhiteSpace(date) && DateTime.TryParse(date, out _);

        public static bool BeInPast(string? date) =>
            !string.IsNullOrWhiteSpace(date) &&
            DateTime.TryParse(date, out var parsed) &&
            parsed <= DateTime.UtcNow;
    }
}
