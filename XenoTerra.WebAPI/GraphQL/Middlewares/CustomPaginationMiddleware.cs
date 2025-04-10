using HotChocolate.Resolvers;

namespace XenoTerra.WebAPI.GraphQL.Middlewares
{
    public class CustomPaginationMiddleware(FieldDelegate next)
    {
        private readonly FieldDelegate _next = next;

        public async Task InvokeAsync(IMiddlewareContext context)
        {
            var first = context.ArgumentValue<int?>("first");
            var after = context.ArgumentValue<string?>("after");
            var last = context.ArgumentValue<int?>("last");
            var before = context.ArgumentValue<string?>("before");

            context.SetScopedState("first", first);
            context.SetScopedState("after", after);
            context.SetScopedState("last", last);
            context.SetScopedState("before", before);

            await _next(context);
        }
    }
}
