﻿using XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads
{
    public record DeleteNoteAdminPayload : Payload<ResultNoteAdminDto>;
}
