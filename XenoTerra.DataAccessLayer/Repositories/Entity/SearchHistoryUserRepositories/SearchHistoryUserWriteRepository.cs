﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.SearchHistoryUserRepositories
{
    public class SearchHistoryUserWriteRepository(AppDbContext context)
        : WriteRepository<SearchHistoryUser, Guid>(context), ISearchHistoryUserWriteRepository
    {
    }

}
