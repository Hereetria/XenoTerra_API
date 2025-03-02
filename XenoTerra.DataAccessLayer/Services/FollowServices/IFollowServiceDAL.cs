
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.FollowServices
{
    
    public interface IFollowServiceDAL : IGenericRepositoryDAL<Follow, ResultFollowDto, ResultFollowByIdDto ,CreateFollowDto, UpdateFollowDto, Guid>

    {

    }
}