using System.Data.Entity;

namespace ChatAura.Models
{
    public class ChatAuraDbContext : DbContext
    {
        public ChatAuraDbContext() : base("DefaultConnection")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }
    }
}
