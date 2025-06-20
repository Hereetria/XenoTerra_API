using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.UserPostTagAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagServices.Write.Admin
{
    public class UserPostTagAdminWriteService(
        IWriteRepository<UserPostTag, Guid> writeRepository,
        IMapper mapper,
        IValidator<CreateUserPostTagAdminDto> createValidator,
        IValidator<UpdateUserPostTagAdminDto> updateValidator,
            AppDbContext dbContext
    )
        : WriteService<UserPostTag, CreateUserPostTagAdminDto, UpdateUserPostTagAdminDto, Guid>(
            writeRepository,
            mapper,
            createValidator,
            updateValidator,
            dbContext
        ),
        IUserPostTagAdminWriteService
    {
    }
}
