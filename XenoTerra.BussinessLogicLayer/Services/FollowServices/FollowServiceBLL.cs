
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.BussinessLogicLayer.Services.FollowServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.FollowServices
{
     public class FollowServiceBLL : GenericRepositoryBLL<Follow, ResultFollowDto, ResultFollowByIdDto, CreateFollowDto, UpdateFollowDto, Guid>, IFollowServiceBLL
    {
        public FollowServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}