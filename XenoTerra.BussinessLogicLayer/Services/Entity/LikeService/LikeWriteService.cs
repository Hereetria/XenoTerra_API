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
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.LikeService
{
    public class LikeWriteService(
            IWriteRepository<Like, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateLikeDto> createValidator,
            IValidator<UpdateLikeDto> updateValidator
        )
            : WriteService<Like, CreateLikeDto, UpdateLikeDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            ILikeWriteService
    {
    }
}
