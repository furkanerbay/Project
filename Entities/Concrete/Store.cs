﻿
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Store : IEntity
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreDescription { get; set; }
    }
}
