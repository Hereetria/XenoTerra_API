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
using XenoTerra.DTOLayer.Dtos.CommentDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.CommentServices.Write.Admin
{
    public class CommentAdminWriteService(
            IWriteRepository<Comment, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateCommentAdminDto> createValidator,
            IValidator<UpdateCommentAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Comment, CreateCommentAdminDto, UpdateCommentAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            ICommentAdminWriteService
    {
        protected override Task PreCreateAsync(CreateCommentAdminDto createDto)
        {
            createDto.CommentedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
