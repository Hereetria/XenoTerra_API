
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.FollowServices
{
        public interface IFollowServiceBLL : IGenericRepositoryBLL<Follow, ResultFollowDto, CreateFollowDto, UpdateFollowDto, Guid>
    {

    }
}