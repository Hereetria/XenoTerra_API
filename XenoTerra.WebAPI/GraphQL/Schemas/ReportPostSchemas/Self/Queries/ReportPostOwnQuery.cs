using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.ReportPostResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.ReportPostQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries.Filters;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReportPostOwnQuery(IMapper mapper, IQueryResolverHelper<ReportPost, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<ReportPost, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(ReportPostOwnFilterType))]
        [UseSorting(typeof(ReportPostOwnSortType))]
        public async Task<ReportPostOwnConnection> GetAllReportPostsAsync(
            [Service] IReportPostQueryService service,
            [Service] IReportPostResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = CreateReportPostAccessFilter(httpContextAccessor);
            var query = service.GetAllQueryable(context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<ReportPost, ResultReportPostWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReportPostOwnConnection, ResultReportPostWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(ReportPostOwnFilterType))]
        [UseSorting(typeof(ReportPostOwnSortType))]
        public async Task<ReportPostOwnConnection> GetReportPostsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IReportPostQueryService service,
            [Service] IReportPostResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = CreateReportPostAccessFilter(httpContextAccessor);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<ReportPost, ResultReportPostWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReportPostOwnConnection, ResultReportPostWithRelationsOwnDto>(connection);
        }

        public async Task<ResultReportPostWithRelationsOwnDto?> GetReportPostByIdAsync(
            string? key,
            [Service] IReportPostQueryService service,
            [Service] IReportPostResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = CreateReportPostAccessFilter(httpContextAccessor);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultReportPostWithRelationsOwnDto>(entity);
        }

        private static Expression<Func<ReportPost, bool>> CreateReportPostAccessFilter(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsExpression<ReportPost, Guid>(
                x => x.ReporterUserId,
                currentUserId
            );
        }
    }
}
