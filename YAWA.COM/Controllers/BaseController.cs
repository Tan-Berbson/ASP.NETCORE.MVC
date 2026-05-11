using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;
using YAWA.COM.Helpers;

namespace YAWA.COM.Controllers
{
    [EnableRateLimiting("fixed")]
    [Authorize]
    public class BaseController : Controller
    {
        protected string CurrentUserId =>
            User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new InvalidOperationException("User  not found.");
        protected string Sanitize(string? input)
        {
            return SanitizerHelper.Sanitize(input);
        }

    }

    
}
