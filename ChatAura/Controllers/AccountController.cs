using ChatAura.Models;
using System.Linq;
using System.Web.Mvc;

namespace ChatAura.Controllers
{
    public class AccountController : Controller
    {
        private readonly ChatAuraDbContext _db;

        public AccountController()
        {
            _db = new ChatAuraDbContext();
        }

        // GET: Account/LoginChoice
        public ActionResult LoginChoice()
        {
            return View();
        }

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
                if (_db.Users.Any(u => u.PhoneNumber == model.PhoneNumber))
                {
                    ModelState.AddModelError("PhoneNumber", "This Phonenumber already exists.");
                    return View(model);
                }

                _db.Users.Add(model);
                _db.SaveChanges();

                return RedirectToAction("Login");
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
                var user = _db.Users.FirstOrDefault(u => u.PhoneNumber == model.PhoneNumber);
                if (user != null)
                {
                    Session["UserId"] = user.Id;

                    return RedirectToAction("Room", "Chat");
                }
            }
            ModelState.AddModelError("", "Incorrect Phonenumber or Password.");
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("LoggedOut");
        }

        public ActionResult LoggedOut()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
