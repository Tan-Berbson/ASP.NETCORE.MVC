using Microsoft.AspNetCore.Mvc;

namespace YAWA.COM.Controllers
{
    public class LessonPlanController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
