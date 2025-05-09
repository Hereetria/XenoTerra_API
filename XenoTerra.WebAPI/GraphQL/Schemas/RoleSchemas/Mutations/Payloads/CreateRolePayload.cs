﻿using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Mutations.Payloads
{
    public record CreateRolePayload : Payload<ResultRoleDto>;
}
