using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.ReportCommentResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.ReportCommentQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.DTOLayer.Dtos.ReportCommentAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
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

            var connection = ConnectionMapper.MapConnection<ReportComment, ResultReportCommentWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReportCommentAdminConnection, ResultReportCommentWithRelationsAdminDto>(connection);
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

            var connection = ConnectionMapper.MapConnection<ReportComment, ResultReportCommentWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReportCommentAdminConnection, ResultReportCommentWithRelationsAdminDto>(connection);
        }

        public async Task<ResultReportCommentWithRelationsAdminDto?> GetReportCommentByIdAsync(
            string? key,
            [Service] IReportCommentQueryService service,
            [Service] IReportCommentResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultReportCommentWithRelationsAdminDto>(entity);
        }
    }

}
