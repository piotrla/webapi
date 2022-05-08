using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
    {

    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Case> Cases { get; set; }
}