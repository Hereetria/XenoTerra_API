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
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.CommentServices
{
    public class CommentWriteService(
            IWriteRepository<Comment, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateCommentDto> createValidator,
            IValidator<UpdateCommentDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Comment, CreateCommentDto, UpdateCommentDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            ICommentWriteService
    {
        protected override Task PreCreateAsync(CreateCommentDto createDto)
        {
            createDto.CommentedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
