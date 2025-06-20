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
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostServices.Write.Own
{
    public class PostOwnWriteService(
            IWriteRepository<Post, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreatePostOwnDto> createValidator,
            IValidator<UpdatePostOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Post, CreatePostOwnDto, UpdatePostOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IPostOwnWriteService
    {
        protected override Task PreCreateAsync(CreatePostOwnDto createDto)
        {
            createDto.CreatedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
