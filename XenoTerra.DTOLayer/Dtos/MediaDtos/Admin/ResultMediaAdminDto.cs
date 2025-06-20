using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Admin
{
    public class ResultMediaAdminDto
    {
        public Guid MediaId { get; init; }
        public string PhotoUrl { get; init; } = string.Empty;

        public Guid SenderId { get; init; }

        public Guid ReceiverId { get; init; }

        public DateTime UploadedAt { get; init; }
    }
}
