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
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsServices.Write.Own
{
    public class RecentChatsOwnWriteService(
            IWriteRepository<RecentChats, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateRecentChatsOwnDto> createValidator,
            IValidator<UpdateRecentChatsOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<RecentChats, CreateRecentChatsOwnDto, UpdateRecentChatsOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IRecentChatsOwnWriteService
    {
    }
}
