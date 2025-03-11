using HotChocolate.Language;
using HotChocolate.Resolvers;

namespace XenoTerra.WebAPI.Utils
{
    public static class GraphQLFieldProvider

    {

        public static List<string> GetSelectedFields(IResolverContext context)

        {

            return context.Selection.SyntaxNode.SelectionSet?.Selections

                .OfType<FieldNode>()

                .Select(s => s.Name.Value)

                .ToList() ?? new List<string>();

        }



        public static IEnumerable<string> GetNestedSelectedFields(IResolverContext context, string fieldName)

        {

            fieldName = fieldName.ToLowerInvariant();



            var field = context.Selection.SyntaxNode.SelectionSet?.Selections

                .OfType<FieldNode>()

                .FirstOrDefault(f => f.Name.Value.ToLowerInvariant() == fieldName);



            return field?.SelectionSet?.Selections

                .OfType<FieldNode>()

                .Select(f => f.Name.Value.ToLowerInvariant())

                .ToList() ?? new List<string>();

        }



        public static int GetRelationalFieldsCount(IResolverContext context)

        {

            return context.Selection.SyntaxNode.SelectionSet?.Selections

                .OfType<FieldNode>()

                .Count(f => f.SelectionSet != null) ?? 0;

        }



        public static bool IsNonRelationalField(IResolverContext context, string fieldName)

        {

            var field = context.Selection.SyntaxNode.SelectionSet?.Selections

                .OfType<FieldNode>()

                .FirstOrDefault(f => f.Name.Value.ToLowerInvariant() == fieldName.ToLowerInvariant());



            return field != null && field.SelectionSet == null;

        }

    }
}
