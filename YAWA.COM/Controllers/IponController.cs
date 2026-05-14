using Microsoft.AspNetCore.Mvc;
using YAWA.COM.Contracts;

namespace YAWA.COM.Controllers
{
    public class IponController : BaseController
{
        private readonly IIponRepository _repo;
        public IponController(IIponRepository repo) => _repo = repo;
    public IActionResult Index()
    {
        return View();
    }
}
}
