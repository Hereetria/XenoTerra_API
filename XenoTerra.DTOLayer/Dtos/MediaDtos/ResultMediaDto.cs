using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.MediaDtos
{
    public record class ResultMediaDto
    {
        public Guid MediaId { get; init; }
        public string PhotoUrl { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime UploadedAt { get; init; }
    }
}
