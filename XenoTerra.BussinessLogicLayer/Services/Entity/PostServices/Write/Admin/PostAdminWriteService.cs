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
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostServices.Write.Admin
{
    public class PostAdminWriteService(
            IWriteRepository<Post, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreatePostAdminDto> createValidator,
            IValidator<UpdatePostAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Post, CreatePostAdminDto, UpdatePostAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IPostAdminWriteService
    {
        protected override Task PreCreateAsync(CreatePostAdminDto createDto)
        {
            createDto.CreatedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
