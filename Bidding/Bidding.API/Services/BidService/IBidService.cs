using Bidding.API.Entities;
using Bidding.API.Models.RequestModels;
using Bidding.API.Models.ResponseModels;
using Microsoft.AspNetCore.Identity;

namespace Bidding.API.Services.JwtService
{
    public interface IBidService
    {
        Task<BidResponse> CreateBid(NewBidRequest bid, string userId);
        Task<ICollection<BidResponse>> GetBidsByListedArticleId(int listedArticleId);
        Task<ICollection<BidResponse>> GetBidsByUserId(string userId);
    }
}
