﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.MessageRepository
{
    public class MessageWriteRepository : WriteRepository<Message, ResultMessageDto, Guid>, IMessageWriteRepository
    {
        public MessageWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }

}
