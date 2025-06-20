using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Helpers;
using XenoTerra.DataAccessLayer.Helpers.Concrete;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryServices.Write.Own
{
    public class StoryOwnWriteService<TEntity, TCreateDto, TKey>(
        IWriteRepository<TEntity, TKey> writeRepository,
        IMapper mapper,
        IValidator<TCreateDto> createValidator,
        AppDbContext dbContext)
        : IStoryOwnWriteService<TEntity, TCreateDto, TKey>
        where TEntity : class
        where TCreateDto : class
        where TKey : notnull
    {
        protected readonly IWriteRepository<TEntity, TKey> _writeRepository = writeRepository;
        protected readonly IMapper _mapper = mapper;
        protected readonly IValidator<TCreateDto> _createValidator = createValidator;
        protected readonly AppDbContext _dbContext = dbContext;

        protected virtual Task PreCreateAsync(TCreateDto createDto) => Task.CompletedTask;

        public async Task<TEntity> CreateStoryAsync(TCreateDto createDto)
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

        public async Task<TEntity> DeleteStoryAsync(TKey key)
        {
            ArgumentGuard.EnsureValidKey(key);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(
                _dbContext,
                ctx => _writeRepository.RemoveAsync(key)
            );
        }
    }
}
