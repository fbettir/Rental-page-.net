using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPage.Dal.Models
{
    public class RentItem
    {

        public RentItem(string name)
        {
            Name = name;
        }

        public RentItem(int id, string name, string description,  int price, bool available, Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            Available = available;
            Price = price;
            Category = category;
        }


        public RentItem() {  }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Price { get; set; } = 0;

        public bool Available { get; set; } = true;

        public Category Category { get; set; }

        public RentedItem? RentedItem { get; set; }


    }
}
