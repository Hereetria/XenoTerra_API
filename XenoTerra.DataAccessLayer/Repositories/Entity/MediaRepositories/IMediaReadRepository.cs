﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.MediaRepositories
{
    public interface IMediaReadRepository : IReadRepository<Media, Guid>
    {
    }
}
