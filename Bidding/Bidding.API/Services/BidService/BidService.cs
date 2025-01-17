
using Bidding.API.Data;
using Bidding.API.Entities;
using Bidding.API.Models.RequestModels;
using Bidding.API.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Bidding.API.Services.JwtService
{
    public class BidService : IBidService
    {
        private readonly ApplicationDbContext _context;
        public BidService(ApplicationDbContext context) 
        {
            this._context = context;
        }

        public async Task<BidResponse> CreateBid(NewBidRequest bid, string userId)
        {
            // new bid must be higher than old bids and the listed article price. after checking create the new bid
            var listedArticle = await _context.ListedArticles.FindAsync(bid.ListedArticleId);
            if (listedArticle == null)
            {
                throw new Exception("Listed article not found");
            }
            if (bid.Price <= listedArticle.Price)
            {
                throw new Exception("Bid price must be higher than listed article price");
            }
            var oldBids = await _context.Bids.Where((b) => b.ListedArticleId == bid.ListedArticleId).ToListAsync();
            foreach (var oldBid in oldBids)
            {
                if (bid.Price <= oldBid.Price)
                {
                    throw new Exception("Bid price must be higher than old bids");
                }
            }
            var newBid = new Bid
            {
                Price = bid.Price,
                ListedArticleId = bid.ListedArticleId,
                ListedArticle = listedArticle,
                UserId = userId,
                User = _context.Users.Find(userId)!
            };
            _context.Bids.Add(newBid);
            await _context.SaveChangesAsync();
            return new BidResponse
            {
                Id = newBid.Id,
                Price = newBid.Price,
                ListedArticleId = newBid.ListedArticleId,
                UserId = newBid.UserId,
                UserName = newBid.User.UserName!
            };
        }

        public async Task<ICollection<BidResponse>> GetBidsByListedArticleId(int listedArticleId)
        {
            return await _context.Bids.Where((b) => b.ListedArticleId == listedArticleId).Select((b) => new BidResponse
            {
                Id = b.Id,
                Price = b.Price,
                ListedArticleId = b.ListedArticleId,
                UserId = b.UserId,
                UserName = b.User.UserName!
            }).ToListAsync();

            
        }

        public async Task<ICollection<BidResponse>> GetBidsByUserId(string userId)
        {
            return await _context.Bids.Where((b) => b.UserId == userId).Select((b) => new BidResponse
            {
                Id = b.Id,
                Price = b.Price,
                ListedArticleId = b.ListedArticleId,
                UserId = b.UserId,
                UserName = b.User.UserName!
            }).ToListAsync();
            
        }
    }
}