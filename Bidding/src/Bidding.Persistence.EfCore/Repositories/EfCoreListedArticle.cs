using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bidding.Domain.Entities;
using Bidding.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bidding.Persistence.EfCore.Repositories
{
    public class EfCoreListedArticleRepository : IListedArticleRepository
    {
        private readonly BiddingDbContext _context;

        public EfCoreListedArticleRepository(BiddingDbContext context)
        {
            _context = context;
        }

        public async Task<ListedArticle> AddAsync(ListedArticle entity)
        {
            await _context.ListedArticles.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.ListedArticles.FindAsync(id);
            if (entity != null)
            {
                _context.ListedArticles.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ListedArticle> GetByIdAsync(Guid id)
        {
            return await _context.ListedArticles.FindAsync(id);
        }

        public async Task<IEnumerable<ListedArticle>> GetAllAsync()
        {
            return await _context.ListedArticles.ToListAsync();
        }

        public async Task UpdateAsync(ListedArticle entity)
        {
            _context.ListedArticles.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}