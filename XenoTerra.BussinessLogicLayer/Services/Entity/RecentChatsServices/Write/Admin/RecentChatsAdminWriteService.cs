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
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsServices.Write.Admin
{
    public class RecentChatsAdminWriteService(
            IWriteRepository<RecentChats, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateRecentChatsAdminDto> createValidator,
            IValidator<UpdateRecentChatsAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<RecentChats, CreateRecentChatsAdminDto, UpdateRecentChatsAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IRecentChatsAdminWriteService
    {
    }
}
