using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryServices.Write.Admin
{
    public interface ISearchHistoryAdminWriteService : IWriteService<SearchHistory, CreateSearchHistoryAdminDto, UpdateSearchHistoryAdminDto, Guid> { }

}
