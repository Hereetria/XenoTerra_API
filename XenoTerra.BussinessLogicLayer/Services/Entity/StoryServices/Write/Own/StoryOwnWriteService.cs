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
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryServices.Write.Own;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryServices.Write.Own
{
    public class StoryOwnWriteService(
        IWriteRepository<Story, Guid> writeRepository,
        IMapper mapper,
        IValidator<CreateStoryOwnDto> createValidator,
        AppDbContext dbContext)
        : IStoryOwnWriteService
    {
        protected readonly IWriteRepository<Story, Guid> _writeRepository = writeRepository;
        protected readonly IMapper _mapper = mapper;
        protected readonly IValidator<CreateStoryOwnDto> _createValidator = createValidator;
        protected readonly AppDbContext _dbContext = dbContext;

        public async Task<Story> CreateStoryAsync(CreateStoryOwnDto createDto)
        {
            ArgumentGuard.EnsureNotNull(createDto);

            await PreCreateAsync(createDto);
            await ValidationGuard.ValidateOrThrowAsync(_createValidator, createDto);

            var entity = MappingGuard.MapOrThrow<Story, CreateStoryOwnDto>(_mapper, createDto);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(
                _dbContext,
                ctx => _writeRepository.InsertAsync(entity)
            );
        }

        public async Task<Story> DeleteStoryAsync(Guid key)
        {
            ArgumentGuard.EnsureValidKey(key);

            return await ServiceExceptionHandler.ExecuteWriteSafelyAsync(
                _dbContext,
                ctx => _writeRepository.RemoveAsync(key)
            );
        }

        protected static Task PreCreateAsync(CreateStoryOwnDto createDto)
        {
            createDto.CreatedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
