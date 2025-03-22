using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos
{
    public class ResultHighlightDto
    {
        public Guid HighlightId { get; set; }
        public string Name { get; set; }
        public string ProfilePicturePath { get; set; }
    }
}
