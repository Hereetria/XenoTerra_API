using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReactionMutationServices
{
    public class ReactionAdminMutationService(IMapper mapper)
        : MutationService<Reaction, ResultReactionDto, CreateReactionDto, UpdateReactionDto, Guid>(mapper),
        IReactionAdminMutationService
    {
    }
}
