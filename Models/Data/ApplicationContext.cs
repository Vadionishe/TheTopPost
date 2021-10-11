using Microsoft.EntityFrameworkCore;

namespace TheTopPost.Models.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<SendCode> SendCodes { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder.UseSqlServer(ConnectionManager.ConnectionConfiguration["ConnectionDB"]);
        }
    }
}
