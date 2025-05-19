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
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.LikeServices
{
    public class LikeWriteService(
            IWriteRepository<Like, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateLikeDto> createValidator,
            IValidator<UpdateLikeDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Like, CreateLikeDto, UpdateLikeDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            ILikeWriteService
    {
        protected override Task PreCreateAsync(CreateLikeDto createDto)
        {
            createDto.LikedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}

