﻿using AutoMapper;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.NoteMutationServices
{
    public class NoteSelfMutationService(IMapper mapper)
        : MutationService<Note, ResultNoteDto, CreateNoteDto, UpdateNoteDto, Guid>(mapper),
        INoteSelfMutationService
    {
    }
}
