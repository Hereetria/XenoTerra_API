using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.ReactionMutationServices
{
    public interface IReactionMutationService : IMutationService<Reaction, ResultReactionDto, CreateReactionDto, UpdateReactionDto, Guid>
    {
    }
}
