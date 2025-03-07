﻿using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.PostTagServices;
using XenoTerra.DTOLayer.Dtos.PostTagDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.PostTag
{
    public class PostTagQuery
    {
        public string GetRandomData()
        {
            return "Default data to prevent query class from being empty.";
        }

        //[UseProjection]
        //[GraphQLDescription("Get all PostTags")]
        //public IQueryable<ResultPostTagDto> GetAllPostTags([Service] IPostTagServiceBLL postTagServiceBLL)
        //{
        //    return postTagServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get PostTag by ID")]
        //public IQueryable<ResultPostTagByIdDto> GetPostTagById(Guid id, [Service] IPostTagServiceBLL postTagServiceBLL)
        //{
        //    var result = postTagServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"PostTag with ID {id} not found");
        //    }
        //    return result;
        //}
    }
}
