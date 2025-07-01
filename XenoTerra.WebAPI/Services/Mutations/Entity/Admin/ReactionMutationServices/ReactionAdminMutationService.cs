using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.ReactionDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReactionMutationServices
{
    public class ReactionAdminMutationService(IMapper mapper)
        : MutationService<Reaction, ResultReactionAdminDto, CreateReactionAdminDto, UpdateReactionAdminDto, Guid>(mapper),
        IReactionAdminMutationService
    {
    }
}