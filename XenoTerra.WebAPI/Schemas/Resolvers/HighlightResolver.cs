using HotChocolate.Language;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.WebAPI.Schemas.DataLoaders;

namespace XenoTerra.WebAPI.Schemas.Resolvers
{
    public class HighlightResolver
    {
        public async Task PopulateHighlightStoriesAsync(
            [Parent] ResultHighlightWithRelationsDto highlightDto,
            StoryHighlightDataLoader highlightStoryDataLoader,
            IResolverContext context)
        {
            var selectedFields = GetSelectedFields(context);

            if (highlightDto.HighlightId == Guid.Empty)
                return;

            // `LoadByIdAsync` metodunu kullanarak verileri getiriyoruz.
            var highlightStoryDict = await highlightStoryDataLoader.LoadStoriesByHighlightIdAsync(highlightDto.HighlightId, selectedFields);

            if (highlightStoryDict == null || !highlightStoryDict.ContainsKey(highlightDto.HighlightId) || highlightStoryDict[highlightDto.HighlightId] == null)
                return;

            // **`ICollection<ResultStoryDto?>` ile uyumlu dönüşüm**
            highlightDto.Stories = highlightStoryDict.GetValueOrDefault(highlightDto.HighlightId)?
                .Select(s => (ResultStoryDto?)s)
                .ToList() ?? new List<ResultStoryDto?>();
        }





        private List<string> GetSelectedFields(IResolverContext context)
        {
            return context.Selection.SyntaxNode.SelectionSet?.Selections
                .OfType<FieldNode>()
                .Select(s => s.Name.Value)
                .ToList() ?? new List<string>();
        }
    }

}
