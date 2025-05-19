using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.FollowServices
{
    public class FollowWriteService(
            IWriteRepository<Follow, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateFollowDto> createValidator,
            IValidator<UpdateFollowDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Follow, CreateFollowDto, UpdateFollowDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IFollowWriteService
    {
        protected override Task PreCreateAsync(CreateFollowDto createDto)
        {
            createDto.FollowedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
