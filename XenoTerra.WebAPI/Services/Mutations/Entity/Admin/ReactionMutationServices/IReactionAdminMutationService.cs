using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReactionMutationServices
{
    public interface IReactionAdminMutationService : IMutationService<Reaction, ResultReactionDto, CreateReactionDto, UpdateReactionDto, Guid>
    {
    }
}
