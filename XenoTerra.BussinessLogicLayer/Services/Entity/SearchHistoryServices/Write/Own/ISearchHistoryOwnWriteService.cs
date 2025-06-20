using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryServices.Write.Own
{
    public interface ISearchHistoryOwnWriteService : IWriteService<SearchHistory, CreateSearchHistoryOwnDto, UpdateSearchHistoryOwnDto, Guid> { }

}
