using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.SavedPostDtos.Admin
{
    public class ResultSavedPostAdminDto
    {
        public Guid SavedPostId { get; init; }
        public Guid UserId { get; init; }
        public Guid PostId { get; init; }
        public DateTime SavedAt { get; init; }
    }
}
