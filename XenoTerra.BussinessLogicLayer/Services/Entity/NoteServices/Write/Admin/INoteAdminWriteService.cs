using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NoteServices.Write.Admin
{
    public interface INoteAdminWriteService : IWriteService<Note, CreateNoteAdminDto, UpdateNoteAdminDto, Guid> { }


}
