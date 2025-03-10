﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.MessageRepository
{
    public class MessageReadRepository : ReadRepository<Message, Guid>, IMessageReadRepository
    {
        public MessageReadRepository(AppDbContext context) : base(context) { }
    }
}
