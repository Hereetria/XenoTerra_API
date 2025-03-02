
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.ReactionServices
{
    
    public interface IReactionServiceDAL : IGenericRepositoryDAL<Reaction, ResultReactionDto, ResultReactionByIdDto ,CreateReactionDto, UpdateReactionDto, Guid>

    {

    }
}