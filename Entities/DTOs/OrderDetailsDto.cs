using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderDetailsDto : IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserProvinceName { get; set; }
        public string StoreName { get; set; }
        public string StoreProvinceName { get; set; }
    }
}
