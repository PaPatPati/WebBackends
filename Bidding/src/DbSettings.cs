namespace Bidding;
{
    public class DbSettings
    {
        public required string Host { get; set; }
        public required int Port { get; set; }
        public required string Database { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        public string ConnectionString => $"Host={Host};Port={Port};Database={Database};Username={Username};Password={Password}";
    }
}