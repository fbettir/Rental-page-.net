using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RentalPage.Bll.Dtos;
using RentalPage.Bll.Exceptions;
using RentalPage.Bll.Interfaces;
using RentalPage.Dal;
using RentalPage.Dal.Models;


namespace RentalPage.Bll.Services
{
    public class RentItemService : IRentItemService
    {

        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public RentItemService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task DeleteRentItemAsync(int rentItemId)
        {
            _context.RentItems.Remove(new RentItem(null!) { Id = rentItemId });
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.RentItems.AnyAsync(p => p.Id == rentItemId))
                    throw new EntityNotFoundException("Nem található az eszköz");
                else
                    throw;
            }
        }

        public async Task DeleteRentItemsAsync()
        {
            foreach (var id in _context.RentItems.Select(e => e.Id))
            {
                RentItem entity = new RentItem(null!) { Id = id };
                _context.RentItems.Remove(entity);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.RentItems.AnyAsync(p => p.Id == entity.Id))
                        throw new EntityNotFoundException("Nem található az eszköz");
                    else
                        throw;
                }
            }
        }

        public async Task<RentItemDto> GetRentItemAsync(int rentItemId)
        {
            return await _context.RentItems
                .ProjectTo<RentItemDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(r => r.Id == rentItemId)
                ?? throw new EntityNotFoundException("Nem található az eszköz");
        }
                
        public async Task<IEnumerable<RentItemDto>> GetRentItemsAsync()
        {
            var item = _context.RentItems;
            var rentitems = await _context.RentItems
                .ProjectTo<RentItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return rentitems;
        }

        public async Task<RentItemDto> InsertRentItemAsync(RentItemDto newRentItem)
        {
            var efRentItem = _mapper.Map<RentItem>(newRentItem);
            _context.RentItems.Add(efRentItem);
            await _context.SaveChangesAsync();
            return await GetRentItemAsync(efRentItem.Id);
        }

        public async Task UpdateRentItemAsync(RentItemDto updatedRentItem, int rentItemId)
        {
            var efRentItem = _mapper.Map<RentItem>(updatedRentItem);
            efRentItem.Id = rentItemId;
            var entry = _context.Attach(efRentItem);
            
            entry.State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.RentItems.AnyAsync(p => p.Id == rentItemId))
                    throw new EntityNotFoundException("Nem található az eszköz");
                else
                    throw;
            }
        }
    }
}
