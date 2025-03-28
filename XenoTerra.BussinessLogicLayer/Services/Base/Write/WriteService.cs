using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Utils;

namespace XenoTerra.BussinessLogicLayer.Services.Base.Write
{
    public class WriteService<TEntity, TCreateDto, TUpdateDto, TKey>(
        IWriteRepository<TEntity, TKey> writeRepository,
        IMapper mapper,
        IValidator<TCreateDto> createValidator,
        IValidator<TUpdateDto> updateValidator) : IWriteService<TEntity, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TCreateDto : class
        where TUpdateDto : class
        where TKey : notnull
    {
        private readonly IWriteRepository<TEntity, TKey> _writeRepository =
            writeRepository ?? throw new ArgumentNullException(nameof(writeRepository), $"{nameof(writeRepository)} cannot be null.");

        private readonly IMapper _mapper =
            mapper ?? throw new ArgumentNullException(nameof(mapper), $"{nameof(mapper)} cannot be null.");

        private readonly IValidator<TCreateDto> _createValidator =
            createValidator ?? throw new ArgumentNullException(nameof(createValidator), $"{nameof(createValidator)} cannot be null.");

        private readonly IValidator<TUpdateDto> _updateValidator =
            updateValidator ?? throw new ArgumentNullException(nameof(updateValidator), $"{nameof(updateValidator)} cannot be null.");

        public async Task<TEntity> CreateAsync(TCreateDto createDto) 
        {
            if (createDto is null)
               throw new ArgumentNullException(nameof(createDto), "The create DTO cannot be null.");

            await ValidateOrThrowAsync(_createValidator, createDto);

            var entity = _mapper.Map<TEntity>(createDto)
                ?? throw new InvalidOperationException(
                $"Mapping failed from {typeof(TCreateDto).Name} to {typeof(TEntity).Name}");

            var entityResult = await _writeRepository.InsertAsync(entity);
            return entityResult;
        }

        public async Task<bool> DeleteAsync(TKey key)
        {
            if (key is null || EqualityComparer<TKey>.Default.Equals(key, default) && typeof(TKey) == typeof(Guid))
                throw new ArgumentException("The key cannot be null or an empty GUID.", nameof(key));

            var result = await _writeRepository.RemoveAsync(key);

            if (!result)
                Console.WriteLine($"[INFO] Delete operation failed: No entity found with key {key}");

            return result;
        }


        public async Task<TEntity> UpdateAsync(TUpdateDto updateDto)
        {
            if(updateDto is null)
                throw new ArgumentNullException(nameof(updateDto), "The update DTO cannot be null.");

            await ValidateOrThrowAsync(_updateValidator, updateDto);

            var entity = _mapper.Map<TEntity>(updateDto)
                ?? throw new InvalidOperationException(
                $"Mapping failed from {typeof(TUpdateDto).Name} to {typeof(TEntity).Name}");

            var entityResult = await _writeRepository.ModifyAsync(entity);
            return entityResult;
        }

        private static async Task ValidateOrThrowAsync<TDto>(IValidator<TDto> validator, TDto dto)
            where TDto : class
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
        }
    }
}
