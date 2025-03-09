using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class StoryHighlight
    {
        public Guid StoryId { get; set; }
        public Story Story { get; set; }

        public Guid HighlightId { get; set; }
        public Highlight Highlight { get; set; }
    }

}
