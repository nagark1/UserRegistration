namespace UserRegistration.Api
{
    public class ClientRepository
    {
        public Client GetById(int clientId)
        {
            var result = new Client();
            result.ClientId = 2;
            result.ClientName = "Widgets - R - Us";
            return result;
        }
    }

    //public class ClientsDbContext : DbContext
    //{
    //    public ClientsDbContext()
    //    {
    //        _ = Database.EnsureCreated();
    //    }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.usesq(@"Data Source=Clients.db");
    //    }

    //    public DbSet<Client> Clients { get; set; }

    //}
}
