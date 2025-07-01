using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.ReactionDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReactionMutationServices
{
    public interface IReactionAdminMutationService : IMutationService<Reaction, ResultReactionAdminDto, CreateReactionAdminDto, UpdateReactionAdminDto, Guid>
    {
    }
}