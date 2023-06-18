using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserProvinceId { get; set; }
        public int StoreId { get; set; }
        public int StoreProvinceId { get; set; }
    }
}
