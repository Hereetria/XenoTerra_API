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
using XenoTerra.DTOLayer.Dtos.FollowDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.FollowServices.Write.Admin
{
    public class FollowAdminWriteService(
            IWriteRepository<Follow, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateFollowAdminDto> createValidator,
            IValidator<UpdateFollowAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Follow, CreateFollowAdminDto, UpdateFollowAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IFollowAdminWriteService
    {
        protected override Task PreCreateAsync(CreateFollowAdminDto createDto)
        {
            createDto.FollowedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
