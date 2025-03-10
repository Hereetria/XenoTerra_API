﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryService
{
    public class SearchHistoryWriteService : WriteService<SearchHistory, ResultSearchHistoryDto, CreateSearchHistoryDto, UpdateSearchHistoryDto, Guid>, ISearchHistoryWriteService
    {
        public SearchHistoryWriteService(IWriteRepository<SearchHistory, Guid> repository, IMapper mapper, SelectorExpressionProvider<SearchHistory, ResultSearchHistoryDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }
}
