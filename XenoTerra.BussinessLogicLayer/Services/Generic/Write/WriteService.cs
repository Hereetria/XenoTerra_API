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
    {
        private readonly IWriteRepository<TEntity, TKey> _repository;
        private readonly IMapper _mapper;
        private readonly SelectorExpressionProvider<TEntity, TResultDto> _selectorExpressionProvider;

        public WriteService(IWriteRepository<TEntity, TKey> repository, IMapper mapper, SelectorExpressionProvider<TEntity, TResultDto> selectorExpressionProvider)
        {
            _repository = repository;
            _mapper = mapper;
            _selectorExpressionProvider = selectorExpressionProvider;
        }

        public async Task<TResultDto> CreateAsync(TCreateDto createDto) 
        {
            if(createDto is null)
               throw new ArgumentNullException(nameof(createDto), "The create dto cannot be null.");

            var entity = _mapper.Map<TEntity>(createDto);
             
            return await _repository.InsertAsync(entity).ContinueWith(task =>
                _mapper.Map<TResultDto>(task.Result)
            );

        }

        public async Task<bool> DeleteAsync(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "The key cannot be null.");

            var result = await _repository.RemoveAsync(key);

            if (!result)
                Console.WriteLine($"[INFO] Delete operation failed: No entity found with key {key}");

            return result;
        }


        public async Task<TResultDto> UpdateAsync(TUpdateDto updateDto)
        {
            if(updateDto is null)
                throw new ArgumentNullException(nameof(updateDto), "The create dto cannot be null.");

            var entity = _mapper.Map<TEntity>(updateDto);

            return await _repository.ModifyAsync(entity).ContinueWith(task =>
                _mapper.Map<TResultDto>(task.Result));
        }
    }
}
