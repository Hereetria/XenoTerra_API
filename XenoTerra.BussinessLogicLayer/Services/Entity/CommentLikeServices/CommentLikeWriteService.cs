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
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.CommentLikeServices
{
    public class CommentLikeWriteService(
            IWriteRepository<CommentLike, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateCommentLikeDto> createValidator,
            IValidator<UpdateCommentLikeDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<CommentLike, CreateCommentLikeDto, UpdateCommentLikeDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            ICommentLikeWriteService
    {
        protected override Task PreCreateAsync(CreateCommentLikeDto createDto)
        {
            createDto.LikedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}

