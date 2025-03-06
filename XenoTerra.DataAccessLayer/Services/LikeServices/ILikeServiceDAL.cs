
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.LikeServices
{
    
    public interface ILikeServiceDAL : IGenericRepositoryDAL<Like, ResultLikeDto, ResultLikeWithRelationsDto CreateLikeDto, UpdateLikeDto, Guid>

    {

    }
}