using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.NoteResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.NoteQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries
{
    public class NoteSelfQuery(IMapper mapper, IQueryResolverHelper<Note, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Note, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(NoteSelfFilterType))]
        [UseSorting(typeof(NoteSelfSortType))]
        public async Task<NoteSelfConnection> GetAllNotesAsync(
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<Note, ResultNoteWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NoteSelfConnection, ResultNoteWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(NoteSelfFilterType))]
        [UseSorting(typeof(NoteSelfSortType))]
        public async Task<NoteSelfConnection> GetNotesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<Note, ResultNoteWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NoteSelfConnection, ResultNoteWithRelationsDto>(connection);
        }

        public async Task<ResultNoteWithRelationsDto?> GetNoteByIdAsync(
            string? key,
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultNoteWithRelationsDto>(entity);
        }
    }
}
