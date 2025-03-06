
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.BussinessLogicLayer.Services.ReactionServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.ReactionServices
{
     public class ReactionServiceBLL : GenericRepositoryBLL<Reaction, ResultReactionDto, ResultReactionWithRelationsDto, CreateReactionDto, UpdateReactionDto, Guid>, IReactionServiceBLL
    {
        public ReactionServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}