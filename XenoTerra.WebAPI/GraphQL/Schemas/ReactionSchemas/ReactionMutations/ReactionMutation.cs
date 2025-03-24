using XenoTerra.BussinessLogicLayer.Services.Entity.ReactionService;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.ReactionMutations
{
    public class ReactionMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Reaction")]
        public async Task<ResultReactionDto> CreateReactionAsync(CreateReactionDto createReactionDto, [Service] IReactionWriteService reactionWriteService)
        {
            var result = await reactionWriteService.CreateAsync(createReactionDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Reaction")]
        public async Task<ResultReactionDto> UpdateReactionAsync(UpdateReactionDto updateReactionDto, [Service] IReactionWriteService reactionWriteService)
        {
            var result = await reactionWriteService.UpdateAsync(updateReactionDto);
            return result;
        }

        [GraphQLDescription("Delete a Reaction by ID")]
        public async Task<bool> DeleteReactionAsync(Guid id, [Service] IReactionWriteService reactionWriteService)
        {
            var result = await reactionWriteService.DeleteAsync(id);
            return result;
        }
    }
}
