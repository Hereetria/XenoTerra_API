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
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.CommentService
{
    public class CommentWriteService(
            IWriteRepository<Comment, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateCommentDto> createValidator,
            IValidator<UpdateCommentDto> updateValidator
        )
            : WriteService<Comment, CreateCommentDto, UpdateCommentDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            ICommentWriteService
    {
    }
}
