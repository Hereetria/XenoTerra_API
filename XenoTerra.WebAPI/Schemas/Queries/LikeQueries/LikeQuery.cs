using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.LikeService;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.LikeQueries
{
    public class LikeQuery
    {
        public async Task<IEnumerable<ResultLikeWithRelationsDto>> GetAllLikesAsync(
            [Service] ILikeReadService likeReadService,
            [Service] LikeResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = likeReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<Like>().AsQueryable();

            var likes = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(likes, context);

            return mapper.Map<List<ResultLikeWithRelationsDto>>(likes);
        }

        public async Task<IEnumerable<ResultLikeWithRelationsDto>> GetLikesByIdsAsync(
            [Service] ILikeReadService likeReadService,
            [Service] LikeResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = likeReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<Like>().AsQueryable();

            var likes = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(likes, context);

            return mapper.Map<List<ResultLikeWithRelationsDto>>(likes);
        }

        public async Task<ResultLikeWithRelationsDto> GetLikeByIdAsync(
            [Service] ILikeReadService likeReadService,
            [Service] LikeResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = likeReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<Like>().AsQueryable();

            var like = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"Like with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(like, context);

            return mapper.Map<ResultLikeWithRelationsDto>(like);
        }

    }
}
