﻿using Agora.BLL.Base;
using Agora.BLL.Interfaces;
using Agora.DAL.Context;
using Agora.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.BLL.Concrete
{
    internal class TransferRepository : Repository<Transfer>, ITransferRepository
    {
        MyDbContext _db;
        public TransferRepository(MyDbContext db) : base(db)
        {
            _db = db;
        }

      
       
    }
}