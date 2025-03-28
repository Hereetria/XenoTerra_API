using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.CommentDtos
{
    public record ResultCommentDto(
        Guid CommentId,
        string Content,
        Guid PostId,
        Guid UserId,
        DateTime CommentedAt
    );
}
