using System.ComponentModel.DataAnnotations;

namespace ChatAura.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Room name is required.")]
        [StringLength(100, ErrorMessage = "The room name must not exceed 100 characters.")]
        public string Name { get; set; }

    }
}
