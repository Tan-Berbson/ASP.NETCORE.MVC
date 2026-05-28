using Microsoft.AspNetCore.Mvc;
using YAWA.COM.Contracts;
using YAWA.COM.Data;
using YAWA.COM.Repositories;

namespace YAWA.COM.Controllers
{

    public class MontlyTaskPlanController : BaseController
    {
        private readonly IMonthlyTaskPlan _repo;
       
        public MontlyTaskPlanController(IMonthlyTaskPlan repo) => _repo = repo;

        public async Task<IActionResult> Index(string? title = null)
        {
            var titles = await _repo.GetDistictTitles(CurrentUserId);
            ViewData["Titles"] = titles;
            ViewData["SelectedTitles"] = title;

            List<MontlyTask> montlytask = new();
            if(!string.IsNullOrWhiteSpace(title))
            {
                montlytask = await _repo.GetByTitle(title,CurrentUserId);
            }
            return View(montlytask);
        }
        
        public async Task<IActionResult> Create()
        {
            return View(new MontlyTask());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MontlyTask tasks)
        {
            if (!ModelState.IsValid)
                return View(tasks);

            await _repo.Create(tasks ,CurrentUserId);
            TempData["Message"] = $"MontlyTask{tasks} Created Successfully";
            return RedirectToAction("Index");
            
        }
       
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _repo.GetOne(id,CurrentUserId);
            if(entity == null)
                return NotFound();

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(MontlyTask tasks)
        {
            if (!ModelState.IsValid)
                return View("Edit", tasks); // ✅ Tell it to use Edit.cshtml

            var existtask = await _repo.GetOne(tasks.Id, CurrentUserId);
            if (existtask == null)
                return NotFound();

            await _repo.UpdateMontly(tasks, CurrentUserId); // ✅ Pass the full object
            return RedirectToAction("Index");
        }


    }
}
