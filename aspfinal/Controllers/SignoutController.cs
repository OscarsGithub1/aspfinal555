using aspfinal.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspfinal.Controllers
{
    public class SignoutController : Controller
    {
        private readonly AuthServices _auth;

        public SignoutController(AuthServices auth)
        {
            _auth = auth;
        }

        public async Task <IActionResult> SignOut()
        {
            await _auth.SignOutAsync();
            return RedirectToAction("Index", "Home");
          //  return RedirectToAction("Index", "Useruser");
            
        }
    }
}
