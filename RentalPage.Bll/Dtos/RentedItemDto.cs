namespace RentalPage.Bll.Dtos
{
    public class RentedItemDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RentItemId { get; set; }

        public DateTime StartOfRenting { get; set; }

        public DateTime EndOfRenting { get; set; }
    }
}