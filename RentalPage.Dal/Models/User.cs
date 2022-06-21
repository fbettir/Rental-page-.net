using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPage.Dal.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<RentedItem> RentedItems { get; set; } = new List<RentedItem>();

        public User(string name)
        {
            Name = name;
        }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public User() { }
    }
}
