using HotChocolate.Language;
using HotChocolate.Resolvers;

namespace XenoTerra.WebAPI.Utils
{
    public static class GraphQLFieldProvider
    {
        public static List<string> GetSelectedFields(IResolverContext context)
        {
            var selections = context.Selection.SyntaxNode.SelectionSet?.Selections;

            if (selections == null)
                return new List<string>();

            var fields = new List<string>();

            foreach (var selection in selections.OfType<FieldNode>())
            {
                if (!selection.Name.Value.Equals("edges", StringComparison.OrdinalIgnoreCase))
                    continue;

                var nodeSelection = selection.SelectionSet?.Selections
                    .OfType<FieldNode>()
                    .FirstOrDefault(f => f.Name.Value.Equals("node", StringComparison.OrdinalIgnoreCase));

                if (nodeSelection == null)
                    continue;

                var nestedFields = nodeSelection.SelectionSet?.Selections
                    .OfType<FieldNode>()
                    .Select(f => f.Name.Value)
                    .Where(name => !name.StartsWith("__", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (nestedFields != null)
                    fields.AddRange(nestedFields);
            }

            return fields.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }

        public static IEnumerable<string> GetNestedSelectedFields(IResolverContext context, string fieldName)
        {
            fieldName = fieldName.ToLowerInvariant();

            var nodeFields = GetNodeFields(context);

            var field = nodeFields
                .FirstOrDefault(f => f.Name.Value.Equals(fieldName, StringComparison.OrdinalIgnoreCase));

            return field?.SelectionSet?.Selections
                .OfType<FieldNode>()
                .Select(f => f.Name.Value.ToLowerInvariant())
                .Where(name => !name.StartsWith("__"))
                .ToList() ?? new List<string>();
        }

        public static int GetRelationalFieldsCount(IResolverContext context)
        {
            var nodeFields = GetNodeFields(context);

            return nodeFields.Count(f => f.SelectionSet != null);
        }

        public static bool IsNonRelationalField(IResolverContext context, string fieldName)
        {
            var nodeFields = GetNodeFields(context);

            var field = nodeFields
                .FirstOrDefault(f => f.Name.Value.Equals(fieldName, StringComparison.OrdinalIgnoreCase));

            return field != null && field.SelectionSet == null;
        }

        public static IReadOnlyList<string> GetRelationalFields(IResolverContext context)
        {
            var fields = GetSelectedFields(context);

            return fields
                .Where(field => !IsNonRelationalField(context, field))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        private static IEnumerable<FieldNode> GetNodeFields(IResolverContext context)
        {
            var selections = context.Selection.SyntaxNode.SelectionSet?.Selections;

            if (selections == null)
                return Enumerable.Empty<FieldNode>();

            var node = selections
                .OfType<FieldNode>()
                .FirstOrDefault(f => f.Name.Value.Equals("edges", StringComparison.OrdinalIgnoreCase))
                ?.SelectionSet?.Selections
                .OfType<FieldNode>()
                .FirstOrDefault(f => f.Name.Value.Equals("node", StringComparison.OrdinalIgnoreCase));

            return node?.SelectionSet?.Selections
                .OfType<FieldNode>()
                .Where(f => !f.Name.Value.StartsWith("__", StringComparison.OrdinalIgnoreCase))
                ?? Enumerable.Empty<FieldNode>();
        }
    }

}
