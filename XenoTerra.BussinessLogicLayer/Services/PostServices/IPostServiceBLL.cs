
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.PostServices
{
        public interface IPostServiceBLL : IGenericRepositoryBLL<Post, ResultPostDto, ResultPostWithRelationsDto, CreatePostDto, UpdatePostDto, Guid>
    {
        IQueryable<ResultPostDto> GetMainstreamPosts(Guid userId, int seed);
        IQueryable<ResultPostDto> GetFollowingPosts(Guid userId);
    }
}