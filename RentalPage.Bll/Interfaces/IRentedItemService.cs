using RentalPage.Bll.Dtos;


namespace RentalPage.Bll.Interfaces
{
    public interface IRentedItemService
    {
        public Task<RentedItemDto> GetRentedItemAsync(int rentedItemId);
        public Task<IEnumerable<RentedItemDto>> GetRentedItemsAsync();
        public Task<RentedItemDto> InsertRentedItemAsync(RentedItemDto newRentedItem);
        public Task UpdateRentedItemAsync(RentedItemDto updatedRentedItem, int rentedItemId);
        public Task DeleteRentedItemAsync(int rentedItemId);
        public Task DeleteRentedItemsAsync();
    }
}
