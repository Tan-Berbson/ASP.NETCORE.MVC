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

        public async Task<IActionResult> Index()
        {
            var taskplan = await _repo.GetAll(CurrentUserId);
            return View(taskplan);
        }
        
        public async Task<IActionResult> Create()
        {
            TempData["Message"] = await _repo.GetDistictTitles(CurrentUserId);
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
            return View(RedirectToAction("Index"));
            
        }


    }
}
