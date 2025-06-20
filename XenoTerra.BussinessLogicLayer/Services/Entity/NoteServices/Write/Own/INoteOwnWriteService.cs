using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NoteServices.Write.Own
{
    public interface INoteOwnWriteService : IWriteService<Note, CreateNoteOwnDto, UpdateNoteOwnDto, Guid> { }


}
