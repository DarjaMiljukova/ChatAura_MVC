using System.Web.Mvc;
using ChatAura.Models;
using Fluent.Infrastructure.FluentModel;

namespace ChatAura.Controllers
{
    public class AccountController : Controller
    {
        // Регистрация
        [HttpGet]
        public ActionResult Register()
        {
            return View(new Models.RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Models.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Логика для регистрации пользователя
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        // Вход
        [HttpGet]
        public ActionResult Login()
        {
            return View(new Models.LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Логика для входа пользователя
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
