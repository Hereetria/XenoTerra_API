using HotChocolate.Language;
using HotChocolate.Resolvers;
using System.Reflection;
using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.Helpers
{
    public static class GraphQLFieldProvider
    {
        public static IReadOnlyList<string> GetSelectedFields(IResolverContext context)
        {
            var selections = context.Selection.SyntaxNode.SelectionSet?.Selections;
            if (selections == null)
                return [];

            var fields = new List<string>();

            if (IsPaginatedMethod(context))
            {
                var edgesField = selections.OfType<FieldNode>()
                    .FirstOrDefault(f => f.Name.Value.Equals("edges", StringComparison.OrdinalIgnoreCase));

                var nodeField = edgesField?.SelectionSet?.Selections
                    .OfType<FieldNode>()
                    .FirstOrDefault(f => f.Name.Value.Equals("node", StringComparison.OrdinalIgnoreCase));

                var nestedFields = nodeField?.SelectionSet?.Selections
                    .OfType<FieldNode>()
                    .Select(f => f.Name.Value)
                    .Where(name => !name.StartsWith("__", StringComparison.OrdinalIgnoreCase));

                if (nestedFields != null)
                    fields.AddRange(nestedFields);
            }
            else
            {
                var directFields = selections
                    .OfType<FieldNode>()
                    .Select(f => f.Name.Value)
                    .Where(name => !name.StartsWith("__", StringComparison.OrdinalIgnoreCase));

                fields.AddRange(directFields);
            }

            return [.. fields.Distinct(StringComparer.OrdinalIgnoreCase)];
        }


        public static IEnumerable<string> GetNestedSelectedFields(IResolverContext context, string fieldName)
        {
            fieldName = fieldName.ToLowerInvariant();

            if (IsPaginatedMethod(context))
            {
                var nodeFields = GetNodeFields(context);

                var field = nodeFields
                    .FirstOrDefault(f => f.Name.Value.Equals(fieldName, StringComparison.OrdinalIgnoreCase));

                return field?.SelectionSet?.Selections
                    .OfType<FieldNode>()
                    .Select(f => f.Name.Value.ToLowerInvariant())
                    .Where(name => !name.StartsWith("__"))
                    .ToList() ?? [];
            }
            else
            {
                var selections = context.Selection.SyntaxNode.SelectionSet?.Selections;
                if (selections is null)
                    return [];

                var targetField = selections
                    .OfType<FieldNode>()
                    .FirstOrDefault(f => f.Name.Value.Equals(fieldName, StringComparison.OrdinalIgnoreCase));

                return targetField?.SelectionSet?.Selections
                    .OfType<FieldNode>()
                    .Select(f => f.Name.Value.ToLowerInvariant())
                    .Where(name => !name.StartsWith("__"))
                    .ToList() ?? [];
            }
        }

        public static int GetRelationalFieldsCount(IResolverContext context)
        {
            var nodeFields = GetNodeFields(context);

            return nodeFields.Count(f => f.SelectionSet != null);
        }

        public static bool IsNonRelationalField(IResolverContext context, string fieldName)
        {
            if (IsPaginatedMethod(context))
            {
                // CASE: Pagination → use nodeFields via edges > node
                var nodeFields = GetNodeFields(context);

                var field = nodeFields
                    .FirstOrDefault(f => f.Name.Value.Equals(fieldName, StringComparison.OrdinalIgnoreCase));

                return field != null && field.SelectionSet == null;
            }
            else
            {
                // CASE: No pagination → read from top-level field selections
                var selections = context.Selection.SyntaxNode.SelectionSet?.Selections;
                if (selections == null)
                    return false;

                var directField = selections
                    .OfType<FieldNode>()
                    .FirstOrDefault(f => f.Name.Value.Equals(fieldName, StringComparison.OrdinalIgnoreCase));

                return directField != null && directField.SelectionSet == null;
            }
        }

        public static IReadOnlyList<string> GetRelationalFields(IResolverContext context)
        {
            var fields = GetSelectedFields(context);

            return [.. fields
                .Where(field => !IsNonRelationalField(context, field))
                .Distinct(StringComparer.OrdinalIgnoreCase)];
        }

        private static IEnumerable<FieldNode> GetNodeFields(IResolverContext context)
        {
            var selections = context.Selection.SyntaxNode.SelectionSet?.Selections;

            if (selections == null)
                return [];

            var node = selections
                .OfType<FieldNode>()
                .FirstOrDefault(f => f.Name.Value.Equals("edges", StringComparison.OrdinalIgnoreCase))
                ?.SelectionSet?.Selections
                .OfType<FieldNode>()
                .FirstOrDefault(f => f.Name.Value.Equals("node", StringComparison.OrdinalIgnoreCase));

            return node?.SelectionSet?.Selections
                .OfType<FieldNode>()
                .Where(f => !f.Name.Value.StartsWith("__", StringComparison.OrdinalIgnoreCase))
                ?? [];
        }

        public static IReadOnlyList<string> GetIdFieldNamesFromInputType<TInput>(ISchema schema)
        {
            var typeName = typeof(TInput).Name;

            var inputType = schema.GetType<INamedInputType>(typeName);

            if (inputType is not IInputObjectType objectType)
                return [];

            var idFields = new List<string>();

            foreach (var field in objectType.Fields)
            {
                if (IsIdType(field.Type))
                {
                    idFields.Add(field.Name);
                }
            }

            return idFields;
        }

        public static IReadOnlyList<string> GetFieldNamesByAttribute<TInput, TAttribute>()
            where TInput : class
            where TAttribute : Attribute
        {
            var type = typeof(TInput);
            var fields = new List<string>();

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (prop.GetCustomAttribute<TAttribute>() is not null)
                {
                    fields.Add(prop.Name);
                }
            }

            return fields;
        }

        private static bool IsIdType(IType type)
        {
            if (type is NonNullType nonNull)
                type = nonNull.Type;

            return type.NamedType() is IdType;
        }

        public static IEnumerable<string> GetSelectedParameterFields<TInput>(
            IResolverContext context,
            string inputArgumentName)
        {
            var variable = context.Selection.SyntaxNode.Arguments
                .FirstOrDefault(arg => arg.Name.Value.Equals(inputArgumentName, StringComparison.OrdinalIgnoreCase));

            if (variable?.Value is not ObjectValueNode inputNode)
                return [];

            return inputNode.Fields
                .Select(f => f.Name.Value)
                .Distinct(StringComparer.OrdinalIgnoreCase);
        }

        public static bool IsPaginatedMethod(IResolverContext context)
        {
            return context.Selection.SyntaxNode.SelectionSet?.Selections
            .OfType<FieldNode>()
            .Any(f => f.Name.Value.Equals("edges", StringComparison.OrdinalIgnoreCase)) == true;
        }
    }
}
