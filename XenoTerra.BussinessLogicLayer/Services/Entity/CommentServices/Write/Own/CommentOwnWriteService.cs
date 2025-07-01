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
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.CommentServices.Write.Own
{
    public class CommentOwnWriteService(
            IWriteRepository<Comment, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateCommentOwnDto> createValidator,
            IValidator<UpdateCommentOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Comment, CreateCommentOwnDto, UpdateCommentOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            ICommentOwnWriteService
    {
        protected override Task PreCreateAsync(CreateCommentOwnDto createDto)
        {
            createDto.CommentedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
