using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.PostService;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.PostQueries
{
    public class PostQuery
    {
        public async Task<IEnumerable<ResultPostWithRelationsDto>> GetAllPostsAsync(
            [Service] IPostReadService postReadService,
            [Service] PostResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = postReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<Post>().AsQueryable();

            var posts = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(posts, context);

            return mapper.Map<List<ResultPostWithRelationsDto>>(posts);
        }

        public async Task<IEnumerable<ResultPostWithRelationsDto>> GetPostsByIdsAsync(
            [Service] IPostReadService postReadService,
            [Service] PostResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = postReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<Post>().AsQueryable();

            var posts = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(posts, context);

            return mapper.Map<List<ResultPostWithRelationsDto>>(posts);
        }

        public async Task<ResultPostWithRelationsDto> GetPostByIdAsync(
            [Service] IPostReadService postReadService,
            [Service] PostResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = postReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<Post>().AsQueryable();

            var post = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"Post with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(post, context);

            return mapper.Map<ResultPostWithRelationsDto>(post);
        }


    }
}
