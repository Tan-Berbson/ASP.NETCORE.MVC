using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YAWA.COM.Contracts;
using YAWA.COM.Data;
using YAWA.COM.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace YAWA.COM.Controllers
{
    public class LessonPlanController : BaseController
    {
        private readonly ILessonPlannerRepository _repo;

        public LessonPlanController(ILessonPlannerRepository repo) => _repo = repo;

        private void SanitizeLesson(LessonPlanner lesson)
        {
            lesson.LessonTittle =
                SanitizerHelper.Sanitize(lesson.LessonTittle);

            lesson.LessonName =
                SanitizerHelper.Sanitize(lesson.LessonName);

            lesson.LessonDescription =
                SanitizerHelper.Sanitize(lesson.LessonDescription);
        }
        public async Task<IActionResult> Index(string? title = null)
        {
            var titles = await _repo.GetDistinctTitles(CurrentUserId);
            ViewData["Titles"] = titles;
            ViewData["SelectedTitle"] = title;

            List<LessonPlanner> lessons = new();

            if (!string.IsNullOrWhiteSpace(title))
            {
                lessons = await _repo.GetByTitle(title, CurrentUserId);
            }
            return View(lessons);
        }
        public async Task<IActionResult> Create()
        {
            ViewData["Titles"] = await _repo.GetDistinctTitles(CurrentUserId);

            return View(new LessonPlanner());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(LessonPlanner lesson)
        {
            if(!ModelState.IsValid)
                return View(lesson);
            SanitizeLesson(lesson);

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

            SanitizeLesson(lesson);

            var existlesson = await _repo.GetOne(lesson.Id, CurrentUserId);
            if(existlesson == null)
                return NotFound();
            await _repo.Update(lesson.Id, new {lesson.LessonName, lesson.LessonDescription}, CurrentUserId);
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
