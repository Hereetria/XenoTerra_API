using AutoMapper;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.HighlightResolvers
{
    public class HighlightResolver : EntityResolver<Highlight, Guid>, IHighlightResolver
    {
        public HighlightResolver(IEntityFieldMapBuilder<Highlight, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
        //public async Task PopulateHighlightStoriesAsync(
        //    [Parent] ResultHighlightWithRelationsDto highlightDto,
        //    StoryHighlightDataLoader highlightStoryDataLoader,
        //    IResolverContext context)
        //{
        //    var selectedFields = GetSelectedFields(context);

        //    if (highlightDto.HighlightId == Guid.Empty)
        //        return;

        //    // `LoadByIdAsync` metodunu kullanarak verileri getiriyoruz.
        //    var highlightStoryDict = await highlightStoryDataLoader.LoadStoriesByHighlightIdAsync(highlightDto.HighlightId, selectedFields);

        //    if (highlightStoryDict == null || !highlightStoryDict.ContainsKey(highlightDto.HighlightId) || highlightStoryDict[highlightDto.HighlightId] == null)
        //        return;

        //    // **`ICollection<ResultStoryDto?>` ile uyumlu dönüşüm**
        //    highlightDto.Stories = highlightStoryDict.GetValueOrDefault(highlightDto.HighlightId)?
        //        .Select(s => (ResultStoryDto?)s)
        //        .ToList() ?? new List<ResultStoryDto?>();
        //}
    }

}
