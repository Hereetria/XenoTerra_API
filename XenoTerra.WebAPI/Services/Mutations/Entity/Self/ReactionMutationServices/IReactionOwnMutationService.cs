using XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.ReactionMutationServices
{
    public interface IReactionOwnMutationService : IMutationService<Reaction, ResultReactionOwnDto, CreateReactionOwnDto, UpdateReactionOwnDto, Guid>
    {
    }
}
