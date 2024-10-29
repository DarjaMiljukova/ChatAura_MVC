using System;
using System.ComponentModel.DataAnnotations;

namespace ChatAura.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "The content of the message is required.")]
        public string Content { get; set; }

        public DateTime Timestamp { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ChatRoom ChatRoom { get; set; }
    }
}
