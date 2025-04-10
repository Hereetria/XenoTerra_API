using HotChocolate.Resolvers;
using HotChocolate.Types.Pagination;

namespace XenoTerra.WebAPI.Utils
{
    public static class ConnectionBuilder
    {
        public static Connection<T> BuildConnection<T>(
            IQueryable<T> query,
            IResolverContext context)
        {
            int? first = context.GetScopedStateOrDefault<int?>("first");
            int? last = context.GetScopedStateOrDefault<int?>("last");
            string? after = context.GetScopedStateOrDefault<string?>("after");
            string? before = context.GetScopedStateOrDefault<string?>("before");

            bool hasPagination = first.HasValue || last.HasValue || !string.IsNullOrEmpty(after) || !string.IsNullOrEmpty(before);

            if (!hasPagination)
            {
                var items = query.ToList();
                List<Edge<T>> edgeList = [.. items.Select((item, index) => new Edge<T>(item, EncodeCursor(index)))];
                var pageInfoResult = new ConnectionPageInfo(false, false, edgeList.FirstOrDefault()?.Cursor, edgeList.LastOrDefault()?.Cursor);

                if (ShouldIncludeTotalCount(context))
                {
                    int totalCount = GetTotalCount(query);
                    return new Connection<T>(edgeList, pageInfoResult, totalCount);
                }
                else
                {
                    return new Connection<T>(edgeList, pageInfoResult);
                }
            }

            int? afterIndex = DecodeCursor(after);
            int? beforeIndex = DecodeCursor(before);

            int skip = afterIndex.HasValue ? afterIndex.Value + 1 : 0;
            int take = first ?? last ?? 10;

            if (beforeIndex.HasValue && beforeIndex.Value < skip + take)
            {
                take = beforeIndex.Value - skip;
            }

            var pageItems = query.Skip(skip).Take(take + 1).ToList();

            bool isForward = first.HasValue;
            bool hasExtraItem = pageItems.Count > take;

            var slicedItems = pageItems.Take(take).ToList();

            var edges = slicedItems.Select((item, index) =>
                new Edge<T>(item, EncodeCursor(skip + index))
            ).ToList();

            string? startCursor = edges.FirstOrDefault()?.Cursor;
            string? endCursor = edges.LastOrDefault()?.Cursor;

            bool hasNextPage = isForward && hasExtraItem;
            bool hasPreviousPage = !isForward && hasExtraItem || skip > 0;

            var pageInfo = new ConnectionPageInfo(
                hasNextPage: hasNextPage,
                hasPreviousPage: hasPreviousPage,
                startCursor: startCursor,
                endCursor: endCursor
            );

            if (ShouldIncludeTotalCount(context))
            {
                int totalCount = GetTotalCount(query);
                return new Connection<T>(edges, pageInfo, totalCount);
            }
            else
            {
                return new Connection<T>(edges, pageInfo);
            }
        }

        private static string EncodeCursor(int index)
        {
            var bytes = BitConverter.GetBytes(index);
            return Convert.ToBase64String(bytes);
        }

        private static int? DecodeCursor(string? cursor)
        {
            if (string.IsNullOrEmpty(cursor)) return null;

            try
            {
                var bytes = Convert.FromBase64String(cursor);
                return BitConverter.ToInt32(bytes, 0);
            }
            catch
            {
                return null;
            }
        }

        private static int GetTotalCount<T>(IQueryable<T> query)
        {
            return query.Count();
        }

        private static bool ShouldIncludeTotalCount(IResolverContext context)
        {
            return context.Selection.SyntaxNode.SelectionSet?.Selections
                .OfType<HotChocolate.Language.FieldNode>()
                .Any(f => f.Name.Value == "totalCount") == true;
        }
    }
}
