using HotChocolate.Language;
using HotChocolate.Resolvers;

namespace XenoTerra.WebAPI.Utils
{
    public static class SelectedFieldsProvider
    {
        public static List<string> GetSelectedFields(IResolverContext context)
        {
            return context.Selection.SyntaxNode.SelectionSet?.Selections
                .OfType<FieldNode>()
                .Select(s => s.Name.Value)
                .ToList() ?? new List<string>();
        }
    }
}
