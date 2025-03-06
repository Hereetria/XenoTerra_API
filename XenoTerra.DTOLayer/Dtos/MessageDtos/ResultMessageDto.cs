using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.MessageDtos
{
    public class ResultMessageDto
    {
        public Guid MessageId { get; set; }
        public string Content { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Header { get; set; }
        public DateTime SentAt { get; set; }
    }
}
