using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.MediaDtos
{
    public record ResultMediaDto(
        Guid MediaId,
        string PhotoUrl,
        Guid UserId,
        DateTime UploadedAt
    );
}
