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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LessonPlanner lesson)
        {
            if(!ModelState.IsValid)
                return View(lesson);

            await _repo.Create(lesson, CurrentUserId);
            TempData["Message"] = $"{lesson} Created Successfully";
            return RedirectToAction("Index");
        }
        public async Task <IActionResult> Edit (int id)
        {
            var entity = await _repo.GetOne(id, CurrentUserId);
            if(entity == null)
                return NotFound();

            return View(entity); 

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(LessonPlanner lesson)
        {
            if(!ModelState.IsValid)
                return View(lesson);

            var existlesson = await _repo.GetOne(lesson.LessonId, CurrentUserId);
            if(existlesson == null)
                return NotFound();
            await _repo.Update(lesson.LessonId, new {lesson.LessonName, lesson.LessonDescription}, CurrentUserId);
            TempData["Message"] = $"{lesson} Updated Successfully";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repo.GetOne(id, CurrentUserId);
            if(entity == null)
                return NotFound();
            return View(entity);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmedDelete(int id, LessonPlanner lesson)
        {
            await _repo.Delete(id, CurrentUserId);
            TempData["Message"] = $"{lesson} Deleted Successfully";

            return RedirectToAction("Index");
        }

    }
}
