using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bidding.Domain.Entities;
using Bidding.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bidding.Persistence.EfCore.Repositories;
{
    public class EfCoreBidRepository : IBidRepository
    {
        private readonly BiddingDbContext _context;

        public EfCoreBidRepository(BiddingDbContext context)
        {
            _context = context;
        }

        public async Task<Bid> GetByIdAsync(Guid id)
        {
            return await _context.Bids.FindAsync(id);
        }

        public async Task<IEnumerable<Bid>> GetAllAsync()
        {
            return await _context.Bids.ToListAsync();
        }

        public async Task AddAsync(Bid bid)
        {
            await _context.Bids.AddAsync(bid);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bid bid)
        {
            _context.Bids.Update(bid);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var bid = await _context.Bids.FindAsync(id);
            if (bid != null)
            {
                _context.Bids.Remove(bid);
                await _context.SaveChangesAsync();
            }
        }
    }
}