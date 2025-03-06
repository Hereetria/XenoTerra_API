
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.ReactionServices
{
        public interface IReactionServiceBLL : IGenericRepositoryBLL<Reaction, ResultReactionDto, ResultReactionWithRelationsDto, CreateReactionDto, UpdateReactionDto, Guid>
    {

    }
}