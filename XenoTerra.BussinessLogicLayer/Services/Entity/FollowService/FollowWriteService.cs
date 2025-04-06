using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.FollowService
{
    public class FollowWriteService(
            IWriteRepository<Follow, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateFollowDto> createValidator,
            IValidator<UpdateFollowDto> updateValidator
        )
            : WriteService<Follow, CreateFollowDto, UpdateFollowDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            IFollowWriteService
    {
    }
}
