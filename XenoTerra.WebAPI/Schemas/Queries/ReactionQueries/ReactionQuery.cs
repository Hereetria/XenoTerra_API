using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReactionService;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ReactionResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.ReactionQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.ReactionQueries
{
    public class ReactionQuery
    {
        private readonly IMapper _mapper;

        public ReactionQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultReactionWithRelationsDto>> GetAllReactionsAsync(
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            IResolverContext context)
        {
            var reactions = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(reactions, context);
            var reactionDtos = _mapper.Map<List<ResultReactionWithRelationsDto>>(reactions);
            return reactionDtos;
        }

        public async Task<IEnumerable<ResultReactionWithRelationsDto>> GetReactionsByIdsAsync(
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var reactions = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(reactions, context);
            var reactionDtos = _mapper.Map<List<ResultReactionWithRelationsDto>>(reactions);
            return reactionDtos;
        }

        public async Task<ResultReactionWithRelationsDto> GetReactionByIdAsync(
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var reaction = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(reaction, context);
            var reactionDto = _mapper.Map<ResultReactionWithRelationsDto>(reaction);
            return reactionDto;
        }
    }

}
