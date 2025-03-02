using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class ViewStory
    {
        public Guid ViewStoryId { get; set; }

        public Guid StoryId { get; set; }
        public Story Story { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime ViewedAt { get; set; }
    }
}
