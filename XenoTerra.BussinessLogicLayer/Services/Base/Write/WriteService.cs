using AutoMapper;
using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using XenoTerra.BussinessLogicLayer.Exceptions.Domain;
using XenoTerra.BussinessLogicLayer.Exceptions.Technical;
using XenoTerra.BussinessLogicLayer.Helpers;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Utils;

namespace XenoTerra.BussinessLogicLayer.Services.Base.Write
{
    public class WriteService<TEntity, TCreateDto, TUpdateDto, TKey>(
        IWriteRepository<TEntity, TKey> writeRepository,
        IMapper mapper,
        IValidator<TCreateDto> createValidator,
        IValidator<TUpdateDto> updateValidator)
        : IWriteService<TEntity, TCreateDto, TUpdateDto, TKey>
        where TEntity : class
        where TCreateDto : class
        where TUpdateDto : class
        where TKey : notnull
    {
        private readonly IWriteRepository<TEntity, TKey> _writeRepository =
            writeRepository ?? throw new ArgumentNullException(nameof(writeRepository));

        private readonly IMapper _mapper =
            mapper ?? throw new ArgumentNullException(nameof(mapper));

        private readonly IValidator<TCreateDto> _createValidator =
            createValidator ?? throw new ArgumentNullException(nameof(createValidator));

        private readonly IValidator<TUpdateDto> _updateValidator =
            updateValidator ?? throw new ArgumentNullException(nameof(updateValidator));

        public async Task<TEntity> CreateAsync(TCreateDto createDto)
        {
            ArgumentGuard.EnsureNotNull(createDto);
            await ValidationGuard.ValidateOrThrowAsync(_createValidator, createDto);

            var entity = MappingGuard.MapOrThrow<TEntity, TCreateDto>(_mapper, createDto);

            return await ExecuteSafelyAsync(() => _writeRepository.InsertAsync(entity));
        }

        public async Task<TEntity> UpdateAsync(TUpdateDto updateDto, IEnumerable<string> modifiedFields)
        {
            ArgumentGuard.EnsureNotNull(updateDto);
            await ValidationGuard.ValidateOrThrowAsync(_updateValidator, updateDto);

            var entity = MappingGuard.MapOrThrow<TEntity, TUpdateDto>(_mapper, updateDto);
            return await ExecuteSafelyAsync(() => _writeRepository.ModifyAsync(entity, modifiedFields));
        }


        public async Task<TEntity> DeleteAsync(TKey key)
        {
            ArgumentGuard.EnsureValidKey(key);

            return await ExecuteSafelyAsync(() => _writeRepository.RemoveAsync(key));
        }

        private async Task<TEntity> ExecuteSafelyAsync(Func<Task<TEntity>> operation)
        {
            try
            {
                return await operation();
            }
            catch (KeyNotFoundException ex)
            {
                throw HandleSqlException(ex);
            }
            catch (InvalidOperationException ex)
            {
                throw HandleSqlException(ex);
            }
            catch (Exception ex)
            {
                throw new UnexpectedRepositoryException(ex);
            }
        }

        private Exception HandleSqlException(Exception ex)
        {
            try
            {
                if (ex.InnerException is not DbUpdateException dbEx ||
                  dbEx.InnerException is not SqlException sqlEx)
                {
                    return ex;
                }

                var dbContext = _writeRepository.GetDbContext();
                var entityType = dbContext.Model.FindEntityType(typeof(TEntity));
                if (entityType is null)
                {
                    return ex;
                }

                var foreignKeys = entityType.GetForeignKeys().Concat(entityType.GetReferencingForeignKeys());

                foreach (var fk in foreignKeys)
                {
                    var constraintName = fk.GetConstraintName();
                    if (!string.IsNullOrEmpty(constraintName) &&
                        sqlEx.Message.Contains(constraintName))
                    {
                        string propertyName = "UnknownProperty";
                        if (fk.Properties.Count > 0 && fk.Properties[0] is { } property)
                        {
                            propertyName = property.Name;
                        }

                        string relatedEntity = fk.PrincipalEntityType?.ClrType?.Name ?? "RelatedEntity";

                        return new ForeignKeyReferenceNotFoundException(propertyName, relatedEntity, ex);
                    }
                }

                return ex;
            }
            catch (Exception handlingEx)
            {
                return new SqlExceptionHandlingFailedException("An error occurred while analyzing SQL constraint exception.", handlingEx);
            }
        }
    }
}
