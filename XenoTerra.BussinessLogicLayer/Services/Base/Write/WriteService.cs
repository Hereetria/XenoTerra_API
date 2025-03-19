using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;

namespace XenoTerra.BussinessLogicLayer.Services.Generic.Write
{
    public class WriteService<TEntity, TResultDto, TCreateDto, TUpdateDto, TKey> : IWriteService<TEntity, TResultDto, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TResultDto : class, new()
        where TCreateDto : class
        where TUpdateDto : class
        where TKey : notnull
    {
        private readonly IWriteRepository<TEntity, TResultDto, TKey> _writeRepository;
        private readonly IMapper _mapper;

        public WriteService(IWriteRepository<TEntity, TResultDto, TKey> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<TResultDto> CreateAsync(TCreateDto createDto) 
        {
            if (createDto is null)
               throw new ArgumentNullException(nameof(createDto), "The create dto cannot be null.");

            var createEntity = _mapper.Map<TEntity>(createDto)
                ?? throw new ArgumentNullException(nameof(createDto), "The create entity cannot be null.");

            var dtoResult = await _writeRepository.InsertAsync(createEntity);
            return dtoResult;
        }

        public async Task<bool> DeleteAsync(TKey key)
        {
            if (key is null || (EqualityComparer<TKey>.Default.Equals(key, default) && typeof(TKey) == typeof(Guid)))
                throw new ArgumentException("The key cannot be null or an empty GUID.", nameof(key));

            var result = await _writeRepository.RemoveAsync(key);

            if (!result)
                Console.WriteLine($"[INFO] Delete operation failed: No entity found with key {key}");

            return result;
        }


        public async Task<TResultDto> UpdateAsync(TUpdateDto updateDto)
        {
            if(updateDto is null)
                throw new ArgumentNullException(nameof(updateDto), "The create dto cannot be null.");

            var updateEntity = _mapper.Map<TEntity>(updateDto)
                ?? throw new ArgumentNullException(nameof(updateDto), "The update entity cannot be null.");

            var dtoResult = await _writeRepository.ModifyAsync(updateEntity);
            return dtoResult;
        }
    }
}
