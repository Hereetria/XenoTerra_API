using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ReportCommentResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.ReportCommentQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries
{
    public class ReportCommentAdminQuery(IMapper mapper, IQueryResolverHelper<ReportComment, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<ReportComment, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(ReportCommentAdminFilterType))]
        [UseSorting(typeof(ReportCommentAdminSortType))]
        public async Task<ReportCommentAdminConnection> GetAllReportCommentsAsync(
            [Service] IReportCommentQueryService service,
            [Service] IReportCommentResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapAdminConnection<ReportComment, ResultReportCommentWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReportCommentAdminConnection, ResultReportCommentWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(ReportCommentAdminFilterType))]
        [UseSorting(typeof(ReportCommentAdminSortType))]
        public async Task<ReportCommentAdminConnection> GetReportCommentsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IReportCommentQueryService service,
            [Service] IReportCommentResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapAdminConnection<ReportComment, ResultReportCommentWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReportCommentAdminConnection, ResultReportCommentWithRelationsDto>(connection);
        }

        public async Task<ResultReportCommentWithRelationsDto?> GetReportCommentByIdAsync(
            string? key,
            [Service] IReportCommentQueryService service,
            [Service] IReportCommentResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultReportCommentWithRelationsDto>(entity);
        }
    }

}
