using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.MessageDtos
{
    public record class ResultMessageDto
    {
        public Guid MessageId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid SenderId { get; init; }
        public Guid ReceiverId { get; init; }
        public string Header { get; init; } = string.Empty;
        public DateTime SentAt { get; init; }
    }
}
