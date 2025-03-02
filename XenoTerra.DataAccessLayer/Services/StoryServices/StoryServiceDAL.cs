

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DataAccessLayer.Repositories;
using AutoMapper.QueryableExtensions;

namespace XenoTerra.DataAccessLayer.Services.StoryServices
{
    
    public class StoryServiceDAL : GenericRepositoryDAL<Story, ResultStoryDto, ResultStoryByIdDto, CreateStoryDto, UpdateStoryDto, Guid>, IStoryServiceDAL

    {

        public StoryServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IQueryable<ResultStoryDto> GetFollowingStories(Guid userId)
        {
            var query = _context.Stories
                .Where(story =>
                    _context.Follows
                        .Where(f => f.FollowerId == userId)
                        .Select(f => f.FollowingId)
                        .Contains(story.UserId))
                .OrderBy(story => _context.ViewStories
                    .Where(view => view.UserId == userId && view.StoryId == story.StoryId)
                    .Any()) 
                .ThenByDescending(story => story.CreatedAt);

            var result = query
                .ProjectTo<ResultStoryDto>(_mapper.ConfigurationProvider);

            return result;
        }

    }
}