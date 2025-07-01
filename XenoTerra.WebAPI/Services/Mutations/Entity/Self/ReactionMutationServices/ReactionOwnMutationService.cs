using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ReactionDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReactionMutationServices
{
    public class ReactionOwnMutationService(IMapper mapper)
        : MutationService<Reaction, ResultReactionOwnDto, CreateReactionOwnDto, UpdateReactionOwnDto, Guid>(mapper),
        IReactionOwnMutationService
    {
    }
}
