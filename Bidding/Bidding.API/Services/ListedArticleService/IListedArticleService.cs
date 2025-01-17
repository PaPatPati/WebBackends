using Bidding.API.Models.RequestModels;
using Bidding.API.Models.ResponseModels;

namespace Bidding.API.Services.JwtService
{
    public interface IListedArticleService
    {
        Task<ListedArticleResponse> CreateListedArticle(NewListedArticleRequest newListedArticle, string userId);
        Task<ListedArticleResponse> UpdateListedArticle(UpdateListedArticleRequest updateListedArticle, string userId);
        Task<ICollection<ListedArticleResponse>> GetListedArticles();
        Task<ICollection<ListedArticleResponse>> GetSoldArticles();
        Task<ICollection<ListedArticleResponse>> GetListedArticlesByUserId(string userId);
        Task<ICollection<ListedArticleResponse>> GetWonArticles(string userId);
    }
}
