using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ChatAura.Models;
using Microsoft.AspNet.Identity;

namespace ChatAura.Controllers
{
    public class ChatController : Controller
    {
        private ChatAuraDbContext db = new ChatAuraDbContext();

        // GET: Chat
        public ActionResult Index()
        {
            var rooms = db.ChatRooms.ToList();
            return View(rooms);
        }

        // GET: Chat/CreateRoom
        public ActionResult CreateRoom()
        {
            return View();
        }

        // POST: Chat/CreateRoom
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRoom(ChatRoom room)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.ChatRooms.Add(room);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Ошибка при сохранении данных: " + ex.InnerException?.Message);
                }
            }
            return View(room);
        }

        // GET: Chat/Room/{id}
        public ActionResult Room(int id)
        {
            var room = db.ChatRooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }

            var messages = db.Messages.Where(m => m.RoomId == id).ToList();
            ViewBag.Messages = messages;
            return View(room);
        }

        // POST: Chat/SendMessage
        [HttpPost]
        [Authorize] // Убедитесь, что только авторизованные пользователи могут отправлять сообщения
        public async Task<ActionResult> SendMessage(int roomId, string content)
        {
            var userId = User.Identity.GetUserId(); // Получите идентификатор текущего пользователя
            var message = new Message
            {
                Content = content,
                Timestamp = DateTime.Now,
                UserId = userId,
                RoomId = roomId // Предполагается, что у вас есть ChatRoomId в сообщении
            };

            db.Messages.Add(message);
            await db.SaveChangesAsync(); // Сохраняем изменения в базе данных

            return RedirectToAction("ChatRoom", new { id = roomId });
        }
    }
}
