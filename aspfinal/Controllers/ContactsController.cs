using aspfinal.Models.Forms;
using Microsoft.AspNetCore.Mvc;

namespace aspfinal.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index( string ReturnUrl)
        {
            var form = new ContactForm { ReturnUrl = ReturnUrl ?? Url.Content("~/") };
            return View(form);
        }

        [HttpPost]
        public IActionResult Index(ContactForm form)
        {
            return View();
        }
    }
}
