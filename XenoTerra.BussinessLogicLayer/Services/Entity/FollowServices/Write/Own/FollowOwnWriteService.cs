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
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.FollowServices.Write.Own
{
    public class FollowOwnWriteService(
            IWriteRepository<Follow, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateFollowOwnDto> createValidator,
            IValidator<UpdateFollowOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Follow, CreateFollowOwnDto, UpdateFollowOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IFollowOwnWriteService
    {
        protected override Task PreCreateAsync(CreateFollowOwnDto createDto)
        {
            createDto.FollowedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
