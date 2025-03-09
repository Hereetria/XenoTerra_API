 

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DataAccessLayer.Repositories;
using AutoMapper.QueryableExtensions;

namespace XenoTerra.DataAccessLayer.Services.StoryServices
{
    
    public class StoryServiceDAL : GenericRepositoryDAL<Story, ResultStoryDto, ResultStoryWithRelationsDto, CreateStoryDto, UpdateStoryDto, Guid>, IStoryServiceDAL

    {

        public StoryServiceDAL(AppDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IQueryable<ResultStoryDto> TGetFollowingStories(Guid userId)
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