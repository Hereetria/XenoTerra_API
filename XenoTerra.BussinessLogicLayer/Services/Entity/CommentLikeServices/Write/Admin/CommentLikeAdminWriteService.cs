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
using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.CommentLikeServices.Write.Admin
{
    public class CommentLikeAdminWriteService(
            IWriteRepository<CommentLike, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateCommentLikeAdminDto> createValidator,
            IValidator<UpdateCommentLikeAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<CommentLike, CreateCommentLikeAdminDto, UpdateCommentLikeAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            ICommentLikeAdminWriteService
    {
        protected override Task PreCreateAsync(CreateCommentLikeAdminDto createDto)
        {
            createDto.LikedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}

