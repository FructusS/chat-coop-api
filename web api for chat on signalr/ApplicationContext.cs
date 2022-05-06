using Microsoft.EntityFrameworkCore;
using System.Reflection;
using web_api_for_chat_on_signalr.Models;

namespace web_api_for_chat_on_signalr
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext()
        {
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
              : base(options)
        {
        }

        // public DbSet<User> Users { get; set; }
        //public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Message>().ToTable("Message");
        }
    }
}
