using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.RoleService;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Queries._Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ReportCommentResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.RoleResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.ReportCommentQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.RoleQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.RoleQueries
{
    public class RoleQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<Role, Guid> _queryResolver;

        public RoleQuery(IMapper mapper, IQueryResolverHelper<Role, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(RoleFilterType))]
        [UseSorting(typeof(RoleSortType))]
        public async Task<IEnumerable<ResultRoleWithRelationsDto>> GetAllRolesAsync(
            [Service] IRoleQueryService service,
            [Service] IRoleResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultRoleWithRelationsDto>>(entities);
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

        public async Task<ResultRoleWithRelationsDto> GetRoleByIdAsync(
            Guid key,
            [Service] IRoleQueryService service,
            [Service] IRoleResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultRoleWithRelationsDto>(entity);
        }
    }
}
