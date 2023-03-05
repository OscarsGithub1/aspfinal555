using aspfinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspfinal.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserServices _userService;

        public AccountController(UserServices userService)
        {
            _userService = userService;
        }


        public async Task <IActionResult> Index(string id)
        {
            var userAccount = await _userService.GetUserAccountAsync(id);
            return View(userAccount);
        }
    }
}
