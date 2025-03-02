using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class SearchHistoryUser
    {
        public Guid SearchHistoryId { get; set; }
        public SearchHistory SearchHistory { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }

}
