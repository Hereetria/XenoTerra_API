﻿using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.PostServices;
using XenoTerra.DataAccessLayer.Services.PostServices;
using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Post
{
    public class PostQuery
    {
        [UseProjection]
        public IQueryable<ResultPostDto> GetPosts(List<Guid>? ids, [Service] IPostServiceBLL service)
    => ids != null && ids.Any() ? service.GetByIdsQuerable(ids) : service.GetByIdsQuerable(service.GetAllIdsAsync().Result);
        //[UseProjection]
        //[GraphQLDescription("Get all Posts")]
        //public IQueryable<ResultPostDto> GetAllPosts([Service] IPostServiceBLL postServiceBLL)
        //{
        //    return postServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get Post by ID")]
        //public IQueryable<ResultPostByIdDto> GetPostById(Guid id, [Service] IPostServiceBLL postServiceBLL)
        //{
        //    var result = postServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"Post with ID {id} not found");
        //    }
        //    return result;
        //}

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [GraphQLDescription("Get mainstream posts")]
        public IQueryable<ResultPostWithRelationsDto> GetMainstreamPosts(
            Guid seed,
            [Service] IPostServiceBLL postServiceBLL)
        {
            var userId = Guid.Parse("bc9fddb5-ed1d-448d-a8a8-08dd5962d80d");
            int seedHash = seed.GetHashCode();
            var result = postServiceBLL.GetMainstreamPosts(userId, seedHash);
            return result;
        }

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [GraphQLDescription("Get following posts")]
        public IQueryable<ResultPostWithRelationsDto> GetFollowingPosts(
            [Service] IPostServiceBLL postServiceBLL)
        {
            var userId = Guid.Parse("9a466137-3217-424f-39b3-08dd59a25e5a");
            var result = postServiceBLL.GetFollowingPosts(userId);
            return result;
        }

    }
}
