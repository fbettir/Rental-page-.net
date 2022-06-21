using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RentalPage.Bll.Dtos;
using RentalPage.Bll.Exceptions;
using RentalPage.Bll.Interfaces;
using RentalPage.Dal;
using RentalPage.Dal.Models;
using RentalPage.Bll.Interfaces;

namespace RentalPage.Bll.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task DeleteUserAsync(int rentItemId)
        {
            _context.Users.Remove(new User(null!) { Id = rentItemId });
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Users.AnyAsync(p => p.Id == rentItemId))
                    throw new EntityNotFoundException("Nem található a felhasználó");
                else
                    throw;
            }
        }

        public async Task DeleteUsersAsync()
        {
            foreach (var item in _context.Users) //TODO: ez itt lehetne a Set<User> - is ld: RentItemService
            {
                _context.Users.Remove(new User(null!) { Id = item.Id });
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.RentItems.AnyAsync(p => p.Id == item.Id))
                        throw new EntityNotFoundException("Nem található a felhasználó");
                    else
                        throw;
                }
            }
        }

        public async Task<UserDto> GetUserAsync(int userId)
        {
            return await _context.Users
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(r => r.Id == userId) 
                ?? throw new EntityNotFoundException("Nem található a felhasználó");
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _context.Users
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return users;
        }

        public async Task<UserDto> InsertUserAsync(UserDto newUser)
        {
            var efUser = _mapper.Map<User>(newUser); 
            _context.Users.Add(efUser);
            await _context.SaveChangesAsync();
            return await GetUserAsync(efUser.Id);

        }

        public async Task UpdateUserAsync(int userId, UserDto updatedUser)
        {
            var efUser = _mapper.Map<User>(updatedUser);
            efUser.Id = updatedUser.Id;
            var entry = _context.Attach(efUser);
            entry.State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Users.AnyAsync(p => p.Id == userId))
                    throw new EntityNotFoundException("Nem található a felhasználó");
                else
                    throw;
            }
        }
    }
}
