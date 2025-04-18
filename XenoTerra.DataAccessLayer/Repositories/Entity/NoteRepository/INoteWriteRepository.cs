﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Repositories.Entity.RoleRepository;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.NoteRepository
{
    public interface INoteWriteRepository : IWriteRepository<Note, Guid>
    {
    }
}
