using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.ReportCommentResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.ReportCommentQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReportCommentSelfQuery(IMapper mapper, IQueryResolverHelper<ReportComment, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<ReportComment, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(ReportCommentSelfFilterType))]
        [UseSorting(typeof(ReportCommentSelfSortType))]
        public async Task<ReportCommentSelfConnection> GetAllReportCommentsAsync(
            [Service] IReportCommentQueryService service,
            [Service] IReportCommentResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = CreateReportCommentAccessFilter(httpContextAccessor);
            var query = service.GetAllQueryable(context, filter);

            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<ReportComment, ResultReportCommentWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReportCommentSelfConnection, ResultReportCommentWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(ReportCommentSelfFilterType))]
        [UseSorting(typeof(ReportCommentSelfSortType))]
        public async Task<ReportCommentSelfConnection> GetReportCommentsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IReportCommentQueryService service,
            [Service] IReportCommentResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = CreateReportCommentAccessFilter(httpContextAccessor);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<ReportComment, ResultReportCommentWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReportCommentSelfConnection, ResultReportCommentWithRelationsDto>(connection);
        }

        public async Task<ResultReportCommentWithRelationsDto?> GetReportCommentByIdAsync(
            string? key,
            [Service] IReportCommentQueryService service,
            [Service] IReportCommentResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = CreateReportCommentAccessFilter(httpContextAccessor);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultReportCommentWithRelationsDto>(entity);
        }

        private static Expression<Func<ReportComment, bool>> CreateReportCommentAccessFilter(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsExpression<ReportComment, Guid>(
                x => x.ReporterUserId,
                currentUserId
            );
        }
    }
}
