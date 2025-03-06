﻿using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.HighlightServices;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Highlight
{
    public class HighlightQuery
    {
        [UseProjection]
        public IQueryable<ResultHighlightDto> GetHighlights(List<Guid>? ids, [Service] IHighlightServiceBLL service)
    => ids != null && ids.Any() ? service.GetByIdsQuerable(ids) : service.GetByIdsQuerable(service.GetAllIdsAsync().Result);
        //[UseProjection]
        //[GraphQLDescription("Get all Highlights")]
        //public IQueryable<ResultHighlightDto> GetAllHighlights([Service] IHighlightServiceBLL highlightServiceBLL)
        //{
        //    return highlightServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get Highlight by ID")]
        //public IQueryable<ResultHighlightByIdDto> GetHighlightById(Guid id, [Service] IHighlightServiceBLL highlightServiceBLL)
        //{
        //    var result = highlightServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"Highlight with ID {id} not found");
        //    }
        //    return result;
        //}
    }
}
