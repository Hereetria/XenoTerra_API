using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.NoteService;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.NoteResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.NoteResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.NoteQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.NoteQueries
{
    public class NoteQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<Note, Guid> _queryResolver;

        public NoteQuery(IMapper mapper, IQueryResolverHelper<Note, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(NoteFilterType))]
        [UseSorting(typeof(NoteSortType))]
        public async Task<IEnumerable<ResultNoteWithRelationsDto>> GetAllNotesAsync(
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultNoteWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(NoteFilterType))]
        [UseSorting(typeof(NoteSortType))]
        public async Task<IEnumerable<ResultNoteWithRelationsDto>> GetNotesByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultNoteWithRelationsDto>>(entities);
        }

        public async Task<ResultNoteWithRelationsDto> GetNoteByIdAsync(
            Guid key,
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultNoteWithRelationsDto>(entity);
        }
    }


}
