
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.LikeServices
{
        public interface ILikeServiceBLL : IGenericRepositoryBLL<Like, ResultLikeDto, ResultLikeByIdDto, CreateLikeDto, UpdateLikeDto, Guid>
    {

    }
}