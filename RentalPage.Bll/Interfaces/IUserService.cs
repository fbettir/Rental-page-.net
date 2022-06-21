using RentalPage.Bll.Dtos;


namespace RentalPage.Bll.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> GetUserAsync(int userId);
        public Task<IEnumerable<UserDto>> GetUsersAsync();
        public Task<UserDto> InsertUserAsync(UserDto newUser);
        public Task UpdateUserAsync(int userId, UserDto updatedUser);
        public Task DeleteUserAsync(int userId);
        public Task DeleteUsersAsync();
    }
}
