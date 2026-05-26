using Microsoft.AspNetCore.Mvc;
using YAWA.COM.Contracts;
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


    }
}
