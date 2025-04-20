using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.BussinessLogicLayer.Services.Entity.RoleService;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NoteService
{
    public interface INoteWriteService : IWriteService<Note, CreateNoteDto, UpdateNoteDto, Guid> { }


}
