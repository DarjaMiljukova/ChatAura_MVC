using System.ComponentModel.DataAnnotations;

namespace ChatAura.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя комнаты обязательно для заполнения.")]
        [StringLength(100, ErrorMessage = "Имя комнаты не должно превышать 100 символов.")]
        public string Name { get; set; }

    }
}
