using aspfinal.Models.Forms;
using aspfinal.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspfinal.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthServices _auth;

        public LoginController(AuthServices auth)
        {
            _auth = auth;
        }

        public IActionResult Index(string ReturnUrl = null!)
        {
            var form = new LoginForm { ReturnUrl = ReturnUrl ?? Url.Content("~/") };
            return View(form);
        }

        [HttpPost]
        public async Task <IActionResult> Index(LoginForm form)
        {

            if(ModelState.IsValid)
            {
                if (await _auth.LoginAsync(form))
                    // return LocalRedirect(form.ReturnUrl!);
                    return RedirectToAction("Index", "Useruser");

            }
            ModelState.AddModelError(string.Empty, "Incorrect email or password");
            return View(form);

            
        }
    }
}
