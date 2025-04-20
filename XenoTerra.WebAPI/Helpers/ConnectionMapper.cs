using AutoMapper;
using HotChocolate.Types.Pagination;

namespace XenoTerra.WebAPI.Helpers
{
    public static class ConnectionMapper
    {
        public static List<Edge<TDestination>> MapEdges<TSource, TDestination>(
            IEnumerable<Edge<TSource>> sourceEdges,
            IMapper mapper)
        {
            return [.. sourceEdges
                .Select(edge => new Edge<TDestination>(
                    mapper.Map<TDestination>(edge.Node),
                    edge.Cursor))];
        }

        public static Connection<TDestination> MapConnection<TSource, TDestination>(
            Connection<TSource> sourceConnection,
            IMapper mapper)
        {
            var mappedEdges = MapEdges<TSource, TDestination>(sourceConnection.Edges, mapper);
            return new Connection<TDestination>(mappedEdges, sourceConnection.Info, sourceConnection.TotalCount);
        }
    }
}
