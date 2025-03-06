
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DataAccessLayer.Services.PostServices
{
    
    public interface IPostServiceDAL : IGenericRepositoryDAL<Post, ResultPostDto, ResultPostWithRelationsDto, CreatePostDto, UpdatePostDto, Guid>

    {
        IQueryable<ResultPostDto> TGetMainstreamPosts(Guid userId, int seed);
        IQueryable<ResultPostDto> TGetFollowingPosts(Guid userId);
    }
}