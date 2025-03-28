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
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryService
{
    public class SearchHistoryWriteService(
            IWriteRepository<SearchHistory, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateSearchHistoryDto> createValidator,
            IValidator<UpdateSearchHistoryDto> updateValidator
        )
            : WriteService<SearchHistory, CreateSearchHistoryDto, UpdateSearchHistoryDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            ISearchHistoryWriteService
    {
    }
}
