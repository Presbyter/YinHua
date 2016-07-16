
using Microsoft.AspNetCore.Mvc;
using YinHua.Areas.Admin.Models;
using YinHua.Data;
using YinHua.Services;

namespace YinHua.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private UserService _userService = new UserService();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPostAttribute]
        [ValidateAntiForgeryTokenAttribute]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var r = _userService.Login(model.MobileNumber, model.Password);
                if (r)
                    return RedirectToAction("Index", "User");

                ModelState.AddModelError("", "手机号码或密码错误");
                return View("_Login", model);
            }
            ModelState.AddModelError("", "验证未通过");
            return View("_Login", model);
        }

        [HttpPostAttribute]
        [ValidateAntiForgeryTokenAttribute]
        public ActionResult Register(Register model)
        {
            User user = new User
            {
                MobileNumber = model.MobileNumber,
                Name = model.Name,
                Sex = model.Sex,
                Email = model.Email,
                Area = model.Area,
                Company = model.Company,
                Password = model.Password
            };
            if (ModelState.IsValid)
            {
                var i = _userService.Create(user);
                if (0 < i)
                {
                    return RedirectToAction("Index", "User");
                }
            }
            return View("_Register", model);
        }
    }
}