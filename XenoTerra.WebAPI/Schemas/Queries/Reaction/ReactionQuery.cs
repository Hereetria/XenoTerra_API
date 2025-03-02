using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.ReactionServices;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Reaction
{
    public class ReactionQuery
    {
        [UseProjection]
        [GraphQLDescription("Get all Reactions")]
        public IQueryable<ResultReactionDto> GetAllReactions([Service] IReactionServiceBLL reactionServiceBLL)
        {
            return reactionServiceBLL.GetAllQuerable();
        }

        [UseProjection]
        [GraphQLDescription("Get Reaction by ID")]
        public IQueryable<ResultReactionByIdDto> GetReactionById(Guid id, [Service] IReactionServiceBLL reactionServiceBLL)
        {
            var result = reactionServiceBLL.GetByIdQuerable(id);
            if (result == null)
            {
                throw new Exception($"Reaction with ID {id} not found");
            }
            return result;
        }
    }
}
