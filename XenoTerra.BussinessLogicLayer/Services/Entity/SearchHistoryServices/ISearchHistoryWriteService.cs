﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryService
{
    public interface ISearchHistoryWriteService : IWriteService<SearchHistory, CreateSearchHistoryDto, UpdateSearchHistoryDto, Guid> { }

}
