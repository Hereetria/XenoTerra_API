using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.EntityLayer.Entities
{
    public class Story
    {
        public Guid StoryId { get; set; }
        public string Path { get; set; } = string.Empty;
        public bool IsVideo { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<ViewStory> ViewStories { get; set; } = [];

        public ICollection<StoryHighlight> StoryHighlights { get; set; } = [];

        public DateTime CreatedAt { get; set; }
    }

}
