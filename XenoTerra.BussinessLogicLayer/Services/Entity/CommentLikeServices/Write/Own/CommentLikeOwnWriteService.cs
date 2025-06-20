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
using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.CommentLikeServices.Write.Own
{
    public class CommentLikeOwnWriteService(
            IWriteRepository<CommentLike, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateCommentLikeOwnDto> createValidator,
            IValidator<UpdateCommentLikeOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<CommentLike, CreateCommentLikeOwnDto, UpdateCommentLikeOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            ICommentLikeOwnWriteService
    {
        protected override Task PreCreateAsync(CreateCommentLikeOwnDto createDto)
        {
            createDto.LikedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}

