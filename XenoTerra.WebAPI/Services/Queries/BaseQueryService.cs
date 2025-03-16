using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Services.Queries
{
    public class BaseQueryService<TEntity, TResultDto, TKey> : IBaseQueryService<TEntity, TResultDto, TKey>
       where TEntity : class
       where TResultDto : class
       where TKey : notnull
    {
        protected readonly IReadService<TEntity, TKey> _readService;
        protected readonly IMapper _mapper;

        public BaseQueryService(IReadService<TEntity, TKey> readService, IMapper mapper)
        {
            _readService = readService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TResultDto>> GetAllAsync(IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = _readService.FetchAllQueryable(selectedFields) ?? Enumerable.Empty<TEntity>().AsQueryable();

            query = ModifyQueryBeforeExecutionForGetAll(query);

            var entities = await query.ToListAsync();
            entities = TransformEntitiesBeforeMappingForGetAll(entities);

            var resultDtos = _mapper.Map<List<TResultDto>>(entities);
            resultDtos = ModifyDtosAfterMappingForGetAll(resultDtos);

            return resultDtos;
        }

        public async Task<IEnumerable<TResultDto>> GetByIdsAsync(List<TKey> keys, IResolverContext context)
        {
            if (keys == null || !keys.Any())
                throw new ArgumentNullException(nameof(keys), "The keys collection cannot be null or empty.");

            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = _readService.FetchByIdsQueryable(keys, selectedFields) ?? Enumerable.Empty<TEntity>().AsQueryable();

            query = ModifyQueryBeforeExecutionForGetByIds(query);

            var entities = await query.ToListAsync();
            entities = TransformEntitiesBeforeMappingForGetByIds(entities);

            var resultDtos = _mapper.Map<List<TResultDto>>(entities);
            resultDtos = ModifyDtosAfterMappingForGetByIds(resultDtos);

            return resultDtos;
        }

        public async Task<TResultDto> GetByIdAsync(TKey key, IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = _readService.FetchByIdQueryable(key, selectedFields) ?? Enumerable.Empty<TEntity>().AsQueryable();

            query = ModifyQueryBeforeExecutionForGetById(query);

            var entity = await query.FirstOrDefaultAsync()
                ?? throw new System.Collections.Generic.KeyNotFoundException($"{typeof(TEntity).Name} with ID {key} was not found.");

            entity = TransformEntityBeforeMappingForGetById(entity);

            var resultDto = _mapper.Map<TResultDto>(entity);
            resultDto = ModifyDtoAfterMappingForGetById(resultDto);

            return resultDto;
        }

        public virtual IQueryable<TEntity> ModifyQueryBeforeExecutionForGetAll(IQueryable<TEntity> query) => query;
        public virtual IQueryable<TEntity> ModifyQueryBeforeExecutionForGetByIds(IQueryable<TEntity> query) => query;
        public virtual IQueryable<TEntity> ModifyQueryBeforeExecutionForGetById(IQueryable<TEntity> query) => query;

        public virtual List<TEntity> TransformEntitiesBeforeMappingForGetAll(List<TEntity> entities) => entities;
        public virtual List<TEntity> TransformEntitiesBeforeMappingForGetByIds(List<TEntity> entities) => entities;
        public virtual TEntity TransformEntityBeforeMappingForGetById(TEntity entity) => entity;

        public virtual List<TResultDto> ModifyDtosAfterMappingForGetAll(List<TResultDto> dtos) => dtos;
        public virtual List<TResultDto> ModifyDtosAfterMappingForGetByIds(List<TResultDto> dtos) => dtos;
        public virtual TResultDto ModifyDtoAfterMappingForGetById(TResultDto dto) => dto;
    }
}
