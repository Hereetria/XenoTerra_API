
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.BussinessLogicLayer.Services.PostServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
using XenoTerra.DataAccessLayer.Services.PostServices;
namespace XenoTerra.BussinessLogicLayer.Services.PostServices
{
     public class PostServiceBLL : GenericRepositoryBLL<Post, ResultPostDto, ResultPostByIdDto, CreatePostDto, UpdatePostDto, Guid>, IPostServiceBLL
    {
        private readonly IPostServiceDAL _postServiceDAL;

        public PostServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory, IPostServiceDAL postServiceDAL)
            : base(repositoryDALFactory)
        {
            _postServiceDAL = postServiceDAL;
        }

        public IQueryable<ResultPostDto> GetMainstreamPosts(Guid userId, int seed)
        {
            var result = _postServiceDAL.TGetMainstreamPosts(userId, seed);
            return result;
        }

        public IQueryable<ResultPostDto> GetFollowingPosts(Guid userId)
        {
            var result = _postServiceDAL.TGetFollowingPosts(userId);
            return result;
        }
    }
}