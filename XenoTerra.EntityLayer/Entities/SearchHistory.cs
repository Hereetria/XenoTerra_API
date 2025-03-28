using XenoTerra.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class SearchHistory
    {
        public Guid SearchHistoryId { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<SearchHistoryUser> SearchedUsers { get; set; } = [];

        public DateTime SearchedAt { get; set; }
    }
}
