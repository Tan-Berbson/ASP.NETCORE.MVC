using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YAWA.COM.Contracts;
using YAWA.COM.Data;

namespace YAWA.COM.Controllers
{
    public class LessonPlanController : BaseController
    {
        private readonly IBaseRepository<LessonPlanner> _repo;

        public LessonPlanController(IBaseRepository<LessonPlanner> repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
          var lesson = await _repo.GetAll(CurrentUserId);
            return View(lesson);
        }
        public async Task<IActionResult> Create(LessonPlanner lesson)
        {
            if(!ModelState.IsValid)
                return View(lesson);

            await _repo.Create(lesson, CurrentUserId);
            TempData["Message"] = $"{lesson} Created Successfully";
            return RedirectToAction("Index");
        }

    }
}
