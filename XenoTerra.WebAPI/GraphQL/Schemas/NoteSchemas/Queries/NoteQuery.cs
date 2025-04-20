using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.NoteResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.NoteQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Queries
{
    public class NoteQuery(IMapper mapper, IQueryResolverHelper<Note, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Note, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(NoteFilterType))]
        [UseSorting(typeof(NoteSortType))]
        public async Task<NoteConnection> GetAllNotesAsync(
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Note, ResultNoteWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NoteConnection, ResultNoteWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(NoteFilterType))]
        [UseSorting(typeof(NoteSortType))]
        public async Task<NoteConnection> GetNotesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Note, ResultNoteWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NoteConnection, ResultNoteWithRelationsDto>(connection);
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
