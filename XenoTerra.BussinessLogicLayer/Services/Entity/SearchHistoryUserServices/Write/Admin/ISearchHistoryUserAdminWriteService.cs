using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserServices.Write.Admin
{
    public interface ISearchHistoryUserAdminWriteService : IWriteService<SearchHistoryUser, CreateSearchHistoryUserAdminDto, UpdateSearchHistoryUserAdminDto, Guid>
    {
    }

}
