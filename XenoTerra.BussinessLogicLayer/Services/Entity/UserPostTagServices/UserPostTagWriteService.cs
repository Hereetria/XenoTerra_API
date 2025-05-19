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
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagServices
{
    public class UserPostTagWriteService(
        IWriteRepository<UserPostTag, Guid> writeRepository,
        IMapper mapper,
        IValidator<CreateUserPostTagDto> createValidator,
        IValidator<UpdateUserPostTagDto> updateValidator,
            AppDbContext dbContext
    )
        : WriteService<UserPostTag, CreateUserPostTagDto, UpdateUserPostTagDto, Guid>(
            writeRepository,
            mapper,
            createValidator,
            updateValidator,
            dbContext
        ),
        IUserPostTagWriteService
    {
    }
}
