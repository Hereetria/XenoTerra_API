using HotChocolate.Types.Pagination;

namespace XenoTerra.WebAPI.Helpers
{
    public static class GraphQLConnectionFactory
    {
        public static TConnection Create<TConnection, TDto>(
            Connection<TDto> connection)
        {
            return (TConnection)Activator.CreateInstance(
                typeof(TConnection),
                connection.Edges,
                connection.Info,
                connection.TotalCount
            )!;
        }
    }
}
