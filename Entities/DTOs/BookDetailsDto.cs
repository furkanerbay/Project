using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BookDetailsDto : IDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string CategoryName { get; set; }
        public int NumberOfPages { get; set; }
        public string ColorName { get; set; }
        public string Description { get; set; }
    }
}
