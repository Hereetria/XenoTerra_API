using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Entity.StoryHighlightRepository;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightService
{
    public class StoryHighlightReadService : ReadService<StoryHighlight, Guid>, IStoryHighlightReadService
    {
        private readonly IStoryHighlightReadRepository _storyHighlightReadRepository;

        public StoryHighlightReadService(IReadRepository<StoryHighlight, Guid> repository, IStoryHighlightReadRepository storyHighlightReadRepository)
            : base(repository)
        {
            _storyHighlightReadRepository = storyHighlightReadRepository;
        }

        public IQueryable<Story> FetchStoryByHighlightIdQueryable(Guid key, IEnumerable<string> selectedProperties)
        {
            if (key == Guid.Empty)
                throw new ArgumentException("Key cannot be empty.", nameof(key));

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<Story>(_repository.GetDbContext(), selectedProperties);

            return _storyHighlightReadRepository.GetStoryByHighlightIdQueryable(key)
                .Select(selector);
        }

        public IQueryable<Story> FetchStoriesByHighlightIdsQueryable(IEnumerable<Guid> keys, IEnumerable<string> selectedProperties)
        {
            if (keys == null || !keys.Any())
                throw new ArgumentNullException(nameof(keys), "The keys collection cannot be null or empty.");

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<Story>(_repository.GetDbContext(), selectedProperties);

            return _storyHighlightReadRepository.GetStoriesByHighlightIdsQueryable(keys)
                .Select(selector);
        }

        public IQueryable<Highlight> FetchHighlightByStoryIdQueryable(Guid key, IEnumerable<string> selectedProperties)
        {
            if (key == Guid.Empty)
                throw new ArgumentException("Key cannot be empty.", nameof(key));

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<Highlight>(_repository.GetDbContext(), selectedProperties);

            return _storyHighlightReadRepository.GetHighlightByStoryIdQueryable(key)
                .Select(selector);
        }

        public IQueryable<Highlight> FetchHighlightsByStoryIdsQueryable(IEnumerable<Guid> keys, IEnumerable<string> selectedProperties)
        {
            if (keys == null || !keys.Any())
                throw new ArgumentNullException(nameof(keys), "The keys collection cannot be null or empty.");

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<Highlight>(_repository.GetDbContext(), selectedProperties);

            return _storyHighlightReadRepository.GetHighlightsByStoryIdsQueryable(keys)
                .Select(selector);
        }
    }

}
