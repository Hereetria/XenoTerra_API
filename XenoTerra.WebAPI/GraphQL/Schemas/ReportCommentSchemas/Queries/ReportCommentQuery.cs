﻿using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.ReportCommentQueries.Filters;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ReportCommentResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.ReportCommentQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.ReportCommentQueries
{
    public class ReportCommentQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<ReportComment, Guid> _queryResolver;

        public ReportCommentQuery(IMapper mapper, IQueryResolverHelper<ReportComment, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(ReportCommentFilterType))]
        [UseSorting(typeof(ReportCommentSortType))]
        public async Task<IEnumerable<ResultReportCommentWithRelationsDto>> GetAllReportCommentsAsync(
            [Service] IReportCommentQueryService service,
            [Service] IReportCommentResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultReportCommentWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(ReportCommentFilterType))]
        [UseSorting(typeof(ReportCommentSortType))]
        public async Task<IEnumerable<ResultReportCommentWithRelationsDto>> GetReportCommentsByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IReportCommentQueryService service,
            [Service] IReportCommentResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultReportCommentWithRelationsDto>>(entities);
        }

        public async Task<ResultReportCommentWithRelationsDto> GetReportCommentByIdAsync(
            Guid key,
            [Service] IReportCommentQueryService service,
            [Service] IReportCommentResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultReportCommentWithRelationsDto>(entity);
        }
    }

}
