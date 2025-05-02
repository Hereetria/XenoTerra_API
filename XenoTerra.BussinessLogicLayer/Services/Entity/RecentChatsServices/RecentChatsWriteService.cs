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
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsService
{
    public class RecentChatsWriteService(
            IWriteRepository<RecentChats, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateRecentChatsDto> createValidator,
            IValidator<UpdateRecentChatsDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<RecentChats, CreateRecentChatsDto, UpdateRecentChatsDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IRecentChatsWriteService
    {
    }
}
