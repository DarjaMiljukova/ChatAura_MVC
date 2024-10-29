using System;
using System.ComponentModel.DataAnnotations;

namespace ChatAura.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Содержимое сообщения обязательно для заполнения.")]
        public string Content { get; set; }

        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }

        // Навигационное свойство
        public virtual ChatRoom ChatRoom { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
