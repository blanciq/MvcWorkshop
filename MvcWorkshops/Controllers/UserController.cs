using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcWorkshops.Models.User;
using MvcWorkshops.Repository;

namespace MvcWorkshops.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _repository;

        public UserController(IRepository<User> repository)
        {
            _repository = repository;
        }

        public ActionResult Login()
        {
            return View(new UserLoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var sha1 = SHA1.Create();
            var passwordHash = GetHashString(sha1.ComputeHash(Encoding.UTF8.GetBytes(model.Password)));
            if (_repository.GetAll().Any(x => x.Username.Equals(model.Username) && x.Password.Equals(passwordHash)))
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);

                return RedirectToAction("Index", "Home");    
            }

            ModelState.AddModelError("Password", "Username or password is invalid");

            return View(model);
        }

        // GET: User
        public ActionResult Register()
        {
            var model = new UserRegisterViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var sha1 = SHA1.Create();
            var passwordHash = GetHashString(sha1.ComputeHash(Encoding.UTF8.GetBytes(model.Password)));
            _repository.Save(new User
            {
                Username = model.Username,
                Password = passwordHash
            });

            FormsAuthentication.SetAuthCookie(model.Username, false);

            return RedirectToAction("Index", "Home");
        }

        private static string GetHashString(byte[] hash)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}