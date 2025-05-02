using AutoMapper;
using FluentValidation;
using XenoTerra.BussinessLogicLayer.Helpers;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Utils;

namespace XenoTerra.BussinessLogicLayer.Services.Base.Write
{
    public class WriteService<TEntity, TCreateDto, TUpdateDto, TKey>(
        IWriteRepository<TEntity, TKey> writeRepository,
        IMapper mapper,
        IValidator<TCreateDto> createValidator,
        IValidator<TUpdateDto> updateValidator,
        AppDbContext dbContext)
        : IWriteService<TEntity, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TCreateDto : class
        where TUpdateDto : class
        where TKey : notnull
    {
        protected readonly IWriteRepository<TEntity, TKey> _writeRepository = writeRepository;
        protected readonly IMapper _mapper = mapper;
        protected readonly IValidator<TCreateDto> _createValidator = createValidator;
        protected readonly IValidator<TUpdateDto> _updateValidator = updateValidator;
        protected readonly AppDbContext _dbContext = dbContext;

        protected virtual Task PreCreateAsync(TCreateDto createDto) => Task.CompletedTask;
        protected virtual Task PreUpdateAsync(TUpdateDto updateDto) => Task.CompletedTask;

        public async Task<TEntity> CreateAsync(TCreateDto createDto)
        {
            ArgumentGuard.EnsureNotNull(createDto);

            await PreCreateAsync(createDto);
            await ValidationGuard.ValidateOrThrowAsync(_createValidator, createDto);

            var entity = MappingGuard.MapOrThrow<TEntity, TCreateDto>(_mapper, createDto);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(
                _dbContext,
                ctx => _writeRepository.InsertAsync(entity)
            );
        }

        public async Task<TEntity> UpdateAsync(TUpdateDto updateDto, IEnumerable<string> modifiedFields)
        {
            ArgumentGuard.EnsureNotNull(updateDto);

            await PreUpdateAsync(updateDto);
            await ValidationGuard.ValidateOrThrowAsync(_updateValidator, updateDto);

            var entity = MappingGuard.MapOrThrow<TEntity, TUpdateDto>(_mapper, updateDto);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(
                _dbContext,
                ctx => _writeRepository.ModifyAsync(entity, modifiedFields)
            );
        }

        public async Task<TEntity> DeleteAsync(TKey key)
        {
            ArgumentGuard.EnsureValidKey(key);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(
                _dbContext,
                ctx => _writeRepository.RemoveAsync(key)
            );
        }
    }
}
