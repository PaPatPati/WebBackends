
using Bidding.API.Data;
using Bidding.API.Entities;
using Bidding.API.Models.RequestModels;
using Bidding.API.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Bidding.API.Services.JwtService
{
    public class ListedArticleService : IListedArticleService
    {

        private readonly ApplicationDbContext _context;
        public ListedArticleService(ApplicationDbContext context) 
        {
            this._context = context;
        }
        public async Task<ListedArticleResponse> CreateListedArticle(NewListedArticleRequest newListedArticle, string userId)
        {
            var listedArticle = new ListedArticle
            {
                Title = newListedArticle.Title,
                Price = newListedArticle.Price,
                IsSold = false,
                Image = newListedArticle.Image,
                UserId = userId,
                User = _context.Users.Find(userId)!
            };
            _context.ListedArticles.Add(listedArticle);
            await _context.SaveChangesAsync();
            return new ListedArticleResponse
            {
                Id = listedArticle.Id,
                Title = listedArticle.Title,
                Price = listedArticle.Price,
                IsSold = listedArticle.IsSold,
                Image = listedArticle.Image,
                UserId = listedArticle.UserId,
                UserName = listedArticle.User!.UserName!
            };
        }

        public async Task<ICollection<ListedArticleResponse>> GetListedArticles()
        {
            return await _context.ListedArticles.Where((article) => !article.IsSold).Select((article) => new ListedArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                Price = article.Bids.Count > 0 ? article.Bids.Max((bid) => bid!.Price) : article.Price,
                IsSold = article.IsSold,
                Image = article.Image,
                UserId = article.UserId,
                UserName = article.User.UserName!
            }).ToListAsync();
        }

        public async Task<ICollection<ListedArticleResponse>> GetListedArticlesByUserId(string userId)
        {
            return await _context.ListedArticles.Where((article) => article.UserId == userId).Select((article) => new ListedArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                Price = article.Bids.Count > 0 ? article.Bids.Max((bid) => bid!.Price) : article.Price,
                IsSold = article.IsSold,
                Image = article.Image,
                UserId = article.UserId,
                UserName = article.User.UserName!
            }).ToListAsync();
        }

        public async Task<ICollection<ListedArticleResponse>> GetSoldArticles()
        {
            return await _context.ListedArticles.Where((article) => article.IsSold).Select((article) => new ListedArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                Price = article.Bids.Count > 0 ? article.Bids.Max((bid) => bid!.Price) : article.Price,
                IsSold = article.IsSold,
                Image = article.Image,
                UserId = article.UserId,
                UserName = article.User.UserName!
            }).ToListAsync();
        }

        public async Task<ICollection<ListedArticleResponse>> GetWonArticles(string userId)
        {
            return await _context.ListedArticles.Where((article) => article.Bids.Any((bid) => bid!.UserId == userId && bid.Price == article.Bids.Max((bid) => bid!.Price))).Select((article) => new ListedArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                Price = article.Bids.Count > 0 ? article.Bids.Max((bid) => bid!.Price) : article.Price,
                IsSold = article.IsSold,
                Image = article.Image,
                UserId = article.UserId,
                UserName = article.User.UserName!
            }).ToListAsync();
        }

        public async Task<ListedArticleResponse> UpdateListedArticle(UpdateListedArticleRequest updateListedArticle, string userId)
        {

            var listedArticle = await _context.ListedArticles.FindAsync(updateListedArticle.Id);
            if (listedArticle == null || listedArticle.UserId != userId)
            {
                throw new Exception("Listed article not found or you are not the owner");
            }

            listedArticle.IsSold = updateListedArticle.IsSold;
            _context.Update(listedArticle);
            await _context.SaveChangesAsync();

            return new ListedArticleResponse
            {
                Id = listedArticle.Id,
                Title = listedArticle.Title,
                Price = listedArticle.Price,
                IsSold = listedArticle.IsSold,
                Image = listedArticle.Image,
                UserId = listedArticle.UserId,
                UserName = ""
            };
        }

    }
}
