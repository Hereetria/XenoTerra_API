using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService
{
    public class BlockUserWriteService(
        IWriteRepository<BlockUser, Guid> writeRepository,
        IMapper mapper,
        IValidator<CreateBlockUserDto> createValidator,
        IValidator<UpdateBlockUserDto> updateValidator
    )
        : WriteService<BlockUser, CreateBlockUserDto, UpdateBlockUserDto, Guid>(
            writeRepository,
            mapper,
            createValidator,
            updateValidator
        ),
        IBlockUserWriteService
    {
    }
}
