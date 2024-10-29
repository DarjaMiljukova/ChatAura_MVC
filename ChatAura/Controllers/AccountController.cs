using ChatAura.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ChatAura.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Register
        public ActionResult Register()
        {
            return View(new ApplicationUser());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ChatAuraDbContext())
                {
                    // Сохраните пользователя в базе данных
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Login"); // Перенаправление на страницу входа после успешной регистрации
            }
            return View(model);
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View(new ApplicationUser());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ChatAuraDbContext())
                {
                    // Проверка пользователя по номеру телефона
                    var user = db.Users.FirstOrDefault(u => u.PhoneNumber == model.PhoneNumber);
                    if (user != null)
                    {
                        // Успешный вход
                        // Здесь можно установить куки, сессии и т.д.
                        Session["UserId"] = user.Id; // Сохранение ID пользователя в сессии

                        // Переход к странице с комнатами
                        return RedirectToAction("Room", "Chat"); // Изменено на "Room"
                    }
                }
            }
            ModelState.AddModelError("", "Неверный номер телефона или пароль.");
            return View(model);
        }
    }
}
