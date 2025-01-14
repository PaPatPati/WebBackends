namespace Bidding.Models;
{
    public enum UserRolesEnum
    {
        Auctioneer,
        Bidder
    }

    public static class UserRoles
    {
        public const string Auctioneer = "Auctioneer";
        public const string Bidder = "Bidder";

        public static string GetRole(UserRolesEnum role)
        {
            return role switch
            {
                UserRolesEnum.Auctioneer => Auctioneer,
                UserRolesEnum.Bidder => Bidder,
                _ => null
            };
        }
    }
}