using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReactionMutationServices
{
    public class ReactionSelfMutationService(IMapper mapper)
        : MutationService<Reaction, ResultReactionDto, CreateReactionDto, UpdateReactionDto, Guid>(mapper),
        IReactionSelfMutationService
    {
    }
}
