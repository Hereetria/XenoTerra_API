
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.BussinessLogicLayer.Services.LikeServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.LikeServices
{
     public class LikeServiceBLL : GenericRepositoryBLL<Like, ResultLikeDto, CreateLikeDto, UpdateLikeDto, Guid>, ILikeServiceBLL
    {
        public LikeServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}