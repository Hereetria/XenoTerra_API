﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.SearchHistoryUserRepository
{
    public interface ISearchHistoryUserReadRepository : IReadRepository<SearchHistoryUser, Guid>
    {
    }
}
