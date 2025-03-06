using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.PostDtos
{
    public class ResultPostDto
    {
        public Guid PostId { get; set; }
        public string Caption { get; set; }
        public string Path { get; set; }
        public bool IsVideo { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
