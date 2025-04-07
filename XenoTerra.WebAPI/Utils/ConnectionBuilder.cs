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
            int? first = context.ArgumentValue<int?>("first");
            int? last = context.ArgumentValue<int?>("last");
            string? after = context.ArgumentValue<string>("after");
            string? before = context.ArgumentValue<string>("before");

            // Validation
            if (first is null && last is null)
                throw new ArgumentException("Must provide 'first' or 'last' for pagination.");

            // Decode cursors
            int? afterIndex = DecodeCursor(after);
            int? beforeIndex = DecodeCursor(before);

            int skip = afterIndex.HasValue ? afterIndex.Value + 1 : 0;
            int take = first ?? last ?? 10;

            if (beforeIndex.HasValue && beforeIndex.Value < skip + take)
            {
                take = beforeIndex.Value - skip;
            }

            // +1 to determine hasNextPage or hasPreviousPage
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

            return new Connection<T>(edges, pageInfo);
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
    }
}
