
using Microsoft.AspNetCore.Mvc;
using YinHua.Data;
using YinHua.Services;

namespace YinHua.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Route("[area]/[controller]/[action]", Name = "[area]_[controller]_[action]")]
    public class UserController : Controller
    {
        private UserService _userService = new UserService();
        public ActionResult Index()
        {
            var list = _userService.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                int i = _userService.Create(model);
                if (0 < i)
                {
                    return Json(new { status = true, expression = "保存成功" });
                }
                return Json(new { status = false, expression = "保存失败" });
            }
            return Json(new { status = false, expression = "验证失败" });
        }
    }
}