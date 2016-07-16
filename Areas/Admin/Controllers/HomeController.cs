using Microsoft.AspNetCore.Mvc;

namespace YinHua.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Route("[area]/[controller]/[action]", Name = "[area]_[controller]_[action]")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}