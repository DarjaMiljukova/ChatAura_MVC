using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;

namespace ChatAura.Models
{
    public class ChatAuraDbContext : IdentityDbContext<ApplicationUser>
    {
        public ChatAuraDbContext() : base("ChatAuraDbContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Message> Messages { get; set; }

        // Добавьте метод для получения сообщений с данными пользователя
        public IQueryable<Message> GetMessagesWithUsers()
        {
            return Messages.Include(m => m.User);
        }
    }
}
