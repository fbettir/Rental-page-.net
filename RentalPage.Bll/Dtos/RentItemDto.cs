using RentalPage.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPage.Bll.Dtos
{
    public class RentItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Price { get; set; } = 0;

        public bool Available { get; set; } = true;

        public Category Category { get; set; }
    }
}
