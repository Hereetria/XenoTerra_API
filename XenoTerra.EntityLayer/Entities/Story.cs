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
        public string Path { get; set; }
        public bool isVideo { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public ICollection<ViewStory> ViewStories { get; set; } = new List<ViewStory>();
        public Highlight Highlight { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
