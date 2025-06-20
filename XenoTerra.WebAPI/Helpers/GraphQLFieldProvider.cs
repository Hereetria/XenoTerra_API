using HotChocolate.Execution.Processing;
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
            var returnType = context.Selection.Field.Type.NamedType();
            if (returnType is not IObjectType objectType)
                return [];

            var selections = context.GetSelections(objectType, context.Selection);
            var fields = new List<string>();

            var edgesSelection = selections
                .FirstOrDefault(s => s.Field.Name.Equals("edges", StringComparison.OrdinalIgnoreCase));

            // Eğer pagination varsa sadece edges > node > fields alınmalı
            if (edgesSelection != null)
            {
                if (edgesSelection.Field.Type.NamedType() is not IObjectType edgeType)
                    return [];

                var edgeSelections = context.GetSelections(edgeType, edgesSelection);
                var nodeSelection = edgeSelections
                    .FirstOrDefault(s => s.Field.Name.Equals("node", StringComparison.OrdinalIgnoreCase));

                if (nodeSelection?.Field.Type.NamedType() is not IObjectType nodeType)
                    return [];

                var nodeFields = context.GetSelections(nodeType, nodeSelection)
                    .Select(s => s.Field.Name)
                    .Where(n => !n.StartsWith("__", StringComparison.OrdinalIgnoreCase));

                fields.AddRange(nodeFields);
                return [.. fields.Distinct(StringComparer.OrdinalIgnoreCase)];
            }

            // Pagination yoksa üst düzey alanları döndür
            foreach (var selection in selections)
            {
                var name = selection.Field.Name;

                if (!name.StartsWith("__", StringComparison.OrdinalIgnoreCase))
                    fields.Add(name);
            }

            return fields.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }

        public static IReadOnlyList<string> GetNonRelationalSelectedFields(IResolverContext context)
        {
            var selectedFields = GetSelectedFields(context);

            return selectedFields
                .Where(field => IsNonRelationalField(context, field))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }





        public static IEnumerable<string> GetNestedSelectedFields(IResolverContext context, string fieldName)
        {
            var returnType = context.Selection.Field.Type.NamedType();
            if (returnType is not IObjectType objectType)
                return [];

            var selections = context.GetSelections(objectType, context.Selection);

            // Normal veya paginated içinde, aranan field'e karşılık gelen selection'ı bul
            var targetSelection = FindFieldSelection(context, selections, fieldName);
            if (targetSelection is null)
                return [];

            var nestedType = targetSelection.Field.Type.NamedType() as IObjectType;
            if (nestedType is null)
                return [];

            var nestedSelections = context.GetSelections(nestedType, targetSelection);
            return nestedSelections
                .Select(s => s.Field.Name)
                .Where(name => !name.StartsWith("__", StringComparison.OrdinalIgnoreCase))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }
        private static ISelection? FindFieldSelection(IResolverContext context, IReadOnlyList<ISelection> selections, string fieldName)
        {
            foreach (var selection in selections)
            {
                var name = selection.Field.Name;

                if (name.Equals("edges", StringComparison.OrdinalIgnoreCase))
                {
                    if (selection.Field.Type.NamedType() is not IObjectType edgeType)
                        continue;

                    var edgeSelections = context.GetSelections(edgeType, selection);
                    var nodeSelection = edgeSelections.FirstOrDefault(s =>
                        s.Field.Name.Equals("node", StringComparison.OrdinalIgnoreCase));

                    if (nodeSelection != null)
                    {
                        var nodeType = nodeSelection.Field.Type.NamedType() as IObjectType;
                        if (nodeType == null)
                            continue;

                        var nodeFields = context.GetSelections(nodeType, nodeSelection);
                        var target = nodeFields.FirstOrDefault(s =>
                            s.Field.Name.Equals(fieldName, StringComparison.OrdinalIgnoreCase));

                        if (target != null)
                            return target;
                    }
                }
                else if (name.Equals(fieldName, StringComparison.OrdinalIgnoreCase))
                {
                    return selection;
                }
            }

            return null;
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
                // edges > node yapısında node selection'ları al
                var nodeSelection = GetNodeSelection(context);
                if (nodeSelection is null)
                    return false;

                var returnType = nodeSelection.Field.Type.NamedType();
                if (returnType is not IObjectType objectType)
                    return false;

                // node içindeki tüm selection'lar (fragment aware)
                var selections = context.GetSelections(objectType, nodeSelection);

                var selected = selections
                    .FirstOrDefault(s => s.Field.Name.Equals(fieldName, StringComparison.OrdinalIgnoreCase));

                // Eğer field var ve SelectionSet yoksa → non-relational
                return selected != null && selected.SyntaxNode.SelectionSet == null;
            }
            else
            {
                var returnType = context.Selection.Field.Type.NamedType();
                if (returnType is not IObjectType objectType)
                    return false;

                var selections = context.GetSelections(objectType, context.Selection);

                var selected = selections
                    .FirstOrDefault(s => s.Field.Name.Equals(fieldName, StringComparison.OrdinalIgnoreCase));

                return selected != null && selected.SyntaxNode.SelectionSet == null;
            }
        }



        public static IReadOnlyList<string> GetRelationalFields(IResolverContext context)
        {
            var fields = GetSelectedFields(context);

            return [.. fields
                .Where(field => !IsNonRelationalField(context, field))
                .Distinct(StringComparer.OrdinalIgnoreCase)];
        }

        private static ISelection? GetNodeSelection(IResolverContext context)
        {
            var returnType = context.Selection.Field.Type.NamedType();
            if (returnType is not IObjectType rootType)
                return null;

            var edgesSelection = context.GetSelections(rootType, context.Selection)
                .FirstOrDefault(s => s.Field.Name.Equals("edges", StringComparison.OrdinalIgnoreCase));

            if (edgesSelection == null)
                return null;

            var edgeType = edgesSelection.Field.Type.NamedType();
            if (edgeType is not IObjectType edgeObjectType)
                return null;

            return context.GetSelections(edgeObjectType, edgesSelection)
                .FirstOrDefault(s => s.Field.Name.Equals("node", StringComparison.OrdinalIgnoreCase));
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
