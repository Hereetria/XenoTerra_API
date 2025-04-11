using XenoTerra.WebAPI.GraphQL.SharedTypes.Payloads;

namespace XenoTerra.WebAPI.Utils
{
    public static class GraphQLExceptionFactory
    {
        public static GraphQLException Create(
            string message,
            string code = "INTERNAL_ERROR")
        {
            return new GraphQLException(
                ErrorBuilder.New()
                    .SetMessage(message)
                    .SetCode(code)
                    .Build());
        }

        public static GraphQLException Create(
            string message,
            IEnumerable<string> errors,
            string code = "VALIDATION_ERROR")
        {
            return new GraphQLException(
                ErrorBuilder.New()
                    .SetMessage(message)
                    .SetCode(code)
                    .SetExtension("errors", errors)
                    .Build());
        }
    }
}
