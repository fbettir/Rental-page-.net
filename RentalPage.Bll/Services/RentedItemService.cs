using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RentalPage.Bll.Dtos;
using RentalPage.Bll.Exceptions;
using RentalPage.Bll.Interfaces;
using RentalPage.Dal;
using RentalPage.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPage.Bll.Services
{
    public class RentedItemService : IRentedItemService
    {

        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public RentedItemService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task DeleteRentedItemAsync(int rentedItemId)
        {
            _context.RentedItems.Remove(new RentedItem(null!) { Id = rentedItemId });
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.RentedItems.AnyAsync(p => p.Id == rentedItemId))
                    throw new EntityNotFoundException("Nem található az eszköz");
                else
                    throw;
            }
        }

        public async Task DeleteRentedItemsAsync()
        {

            foreach (var id in _context.RentedItems.Select(e => e.Id))
            {
                RentedItem entity = new RentedItem(null!) { Id = id };
                _context.RentedItems.Remove(entity);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.RentedItems.AnyAsync(p => p.Id == entity.Id))
                        throw new EntityNotFoundException("Nem található az eszköz");
                    else
                        throw;
                }
            }
        }

        public async Task<RentedItemDto> GetRentedItemAsync(int rentedItemId)
        {
            return await _context.RentedItems
                .ProjectTo<RentedItemDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(r => r.Id == rentedItemId)
                ?? throw new EntityNotFoundException("Nem található az eszköz");
        }

        public async Task<IEnumerable<RentedItemDto>> GetRentedItemsAsync()
        {
            var item = _context.RentedItems;
            var renteditems = await _context.RentedItems
                .ProjectTo<RentedItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return renteditems;
        }

        public async Task<RentedItemDto> InsertRentedItemAsync(RentedItemDto newRentedItem)
        {
            var efRentedItem = _mapper.Map<RentedItem>(newRentedItem);
            _context.RentedItems.Add(efRentedItem);
            await _context.SaveChangesAsync();
            return await GetRentedItemAsync(efRentedItem.Id);
        }

        public async Task UpdateRentedItemAsync(RentedItemDto updatedRentedItem, int rentedItemId)
        {
            var efRentedItem = _mapper.Map<RentedItem>(updatedRentedItem);
            efRentedItem.Id = updatedRentedItem.Id;
            var entry = _context.Attach(efRentedItem);
            entry.State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.RentedItems.AnyAsync(p => p.Id == rentedItemId))
                    throw new EntityNotFoundException("Nem található az eszköz");
                else
                    throw;
            }
        }
    }
}
