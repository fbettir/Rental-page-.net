using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPage.Dal.Models
{
    public class RentedItem
    {
        public RentedItem( )
        {
        }

        public RentedItem(object value)
        {
            Value = value;
        }

        public RentedItem(int userId, int rentItemId, 
            DateTime startOfRenting, DateTime endOfRenting)
        {
            UserId = userId;
            RentItemId = rentItemId;
            StartOfRenting = startOfRenting;
            EndOfRenting = endOfRenting;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int RentItemId { get; set; }

        public User User { get; set; } = null!;

        public RentItem RentItem { get; set; } = null!;

        public DateTime StartOfRenting { get; set; } 

        public DateTime EndOfRenting { get; set; }
        public object Value { get; }
    }
}
