using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.ReactionServices;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.Reaction
{
    public class ReactionMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Reaction")]
        public async Task<ResultReactionByIdDto> CreateReactionAsync(CreateReactionDto createReactionDto, [Service] IReactionServiceBLL reactionServiceBLL)
        {
            var result = await reactionServiceBLL.CreateAsync(createReactionDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Reaction")]
        public async Task<ResultReactionByIdDto> UpdateReactionAsync(UpdateReactionDto updateReactionDto, [Service] IReactionServiceBLL reactionServiceBLL)
        {
            var result = await reactionServiceBLL.UpdateAsync(updateReactionDto);
            return result;
        }

        [GraphQLDescription("Delete a Reaction by ID")]
        public async Task<bool> DeleteReactionAsync(Guid id, [Service] IReactionServiceBLL reactionServiceBLL)
        {
            var result = await reactionServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
