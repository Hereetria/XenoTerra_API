namespace XenoTerra.WebAPI.Helpers
{
    public static class GuidParser
    {

        public static Guid ParseGuidOrThrow(
            string? value,
            string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw GraphQLExceptionFactory.Create(
                    "Missing primary key.",
                    [$"'{fieldName}' is required and cannot be empty."],
                    "INVALID_GUID"
                );
            }

            if (!Guid.TryParse(value, out var parsed))
            {
                throw GraphQLExceptionFactory.Create(
                    "Invalid primary key format.",
                    [$"'{fieldName}' must be a valid GUID."],
                    "INVALID_GUID"
                );
            }

            return parsed;
        }

        public static IEnumerable<Guid> ParseGuidOrThrow(
            IEnumerable<string>? values,
            string fieldName)
        {
            if (values is null || !values.Any())
            {
                throw GraphQLExceptionFactory.Create(
                    "Missing primary keys.",
                    [$"'{fieldName}' must contain at least one GUID."],
                    "INVALID_GUID_LIST"
                );
            }

            var result = new List<Guid>();
            var invalids = new List<string>();

            foreach (var value in values)
            {
                if (Guid.TryParse(value, out var parsed))
                {
                    result.Add(parsed);
                }
                else
                {
                    invalids.Add(value);
                }
            }

            if (invalids.Count > 0)
            {
                throw GraphQLExceptionFactory.Create(
                    "Invalid primary keys.",
                    [$"'{fieldName}' contains invalid GUID(s): {string.Join(", ", invalids)}"],
                    "INVALID_GUID_LIST"
                );
            }

            return result;
        }
    }
}
