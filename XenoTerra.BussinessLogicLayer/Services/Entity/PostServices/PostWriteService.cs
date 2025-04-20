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
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostService
{
    public class PostWriteService(
            IWriteRepository<Post, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreatePostDto> createValidator,
            IValidator<UpdatePostDto> updateValidator
        )
            : WriteService<Post, CreatePostDto, UpdatePostDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            IPostWriteService
    {
    }
}
