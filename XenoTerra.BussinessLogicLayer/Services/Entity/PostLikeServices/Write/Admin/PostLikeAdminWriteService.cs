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
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostLikeServices.Write.Admin
{
    public class PostLikeAdminWriteService(
            IWriteRepository<PostLike, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreatePostLikeAdminDto> createValidator,
            IValidator<UpdatePostLikeAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<PostLike, CreatePostLikeAdminDto, UpdatePostLikeAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IPostLikeAdminWriteService
    {
        protected override Task PreCreateAsync(CreatePostLikeAdminDto createDto)
        {
            createDto.LikedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}

