using XenoTerra.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class Highlight
    {
        public Guid HighlightId { get; set; }
        public string Name { get; set; }
        public string ProfilePicturePath { get; set; }

        public ICollection<StoryHighlight> StoryHighlights { get; set; } = new List<StoryHighlight>();
    }

}
