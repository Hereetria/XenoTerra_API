using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.ReportStoryResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.ReportStoryQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class ReportStoryAdminQuery(IMapper mapper, IQueryResolverHelper<ReportStory, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<ReportStory, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(ReportStoryAdminFilterType))]
        [UseSorting(typeof(ReportStoryAdminSortType))]
        public async Task<ReportStoryAdminConnection> GetAllReportStorysAsync(
            [Service] IReportStoryQueryService service,
            [Service] IReportStoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<ReportStory, ResultReportStoryWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReportStoryAdminConnection, ResultReportStoryWithRelationsAdminDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(ReportStoryAdminFilterType))]
        [UseSorting(typeof(ReportStoryAdminSortType))]
        public async Task<ReportStoryAdminConnection> GetReportStorysByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IReportStoryQueryService service,
            [Service] IReportStoryResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<ReportStory, ResultReportStoryWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReportStoryAdminConnection, ResultReportStoryWithRelationsAdminDto>(connection);
        }

        public async Task<ResultReportStoryWithRelationsAdminDto?> GetReportStoryByIdAsync(
            string? key,
            [Service] IReportStoryQueryService service,
            [Service] IReportStoryResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultReportStoryWithRelationsAdminDto>(entity);
        }
    }

}
