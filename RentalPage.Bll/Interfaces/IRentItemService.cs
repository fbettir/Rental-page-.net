using RentalPage.Bll.Dtos;


namespace RentalPage.Bll.Interfaces
{
    public interface IRentItemService
    {
        public Task<RentItemDto> GetRentItemAsync(int rentItemId);
        public Task<IEnumerable<RentItemDto>> GetRentItemsAsync();
        public Task<RentItemDto> InsertRentItemAsync(RentItemDto newRentItem);
        public Task UpdateRentItemAsync( RentItemDto updatedRentItem, int rentItemId);
        public Task DeleteRentItemAsync(int rentItemId);
        public Task DeleteRentItemsAsync();
    }
}
