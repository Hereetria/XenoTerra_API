using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.ReactionMutationServices
{
    public class ReactionMutationService(IMapper mapper)
        : MutationService<Reaction, ResultReactionDto, CreateReactionDto, UpdateReactionDto, Guid>(mapper),
        IReactionMutationService
    {
    }
}
