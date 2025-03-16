using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReactionService;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.ReactionQueries
{
    public class ReactionQuery
    {
        public async Task<IEnumerable<ResultReactionWithRelationsDto>> GetAllReactionsAsync(
            [Service] IReactionReadService reactionReadService,
            [Service] ReactionResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = reactionReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<Reaction>().AsQueryable();

            var reactions = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(reactions, context);

            return mapper.Map<List<ResultReactionWithRelationsDto>>(reactions);
        }

        public async Task<IEnumerable<ResultReactionWithRelationsDto>> GetReactionsByIdsAsync(
            [Service] IReactionReadService reactionReadService,
            [Service] ReactionResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = reactionReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<Reaction>().AsQueryable();

            var reactions = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(reactions, context);

            return mapper.Map<List<ResultReactionWithRelationsDto>>(reactions);
        }

        public async Task<ResultReactionWithRelationsDto> GetReactionByIdAsync(
            [Service] IReactionReadService reactionReadService,
            [Service] ReactionResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = reactionReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<Reaction>().AsQueryable();

            var reaction = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"Reaction with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(reaction, context);

            return mapper.Map<ResultReactionWithRelationsDto>(reaction);
        }

    }
}
