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
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostService
{
    public class SavedPostWriteService(
            IWriteRepository<SavedPost, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateSavedPostDto> createValidator,
            IValidator<UpdateSavedPostDto> updateValidator
        )
            : WriteService<SavedPost, CreateSavedPostDto, UpdateSavedPostDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            ISavedPostWriteService
    {
    }
}
