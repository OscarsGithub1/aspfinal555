using aspfinal.Context;
using aspfinal.Models.Forms;
using aspfinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspfinal.Models.Identity;
using aspfinal.Models.Identitytestio;
using aspfinal.Models.Entities;
using aspfinal.Models.ViewModelsHansvideo.Accounthansvideo;

namespace aspfinal.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AuthServices _auth;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentityContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ProfileHandler _profileHandler;
        public RegisterController(AuthServices auth, UserManager<IdentityUser> userManager, IdentityContext context, SignInManager<IdentityUser> signInManager, ProfileHandler profileHandler)
        {
            _auth = auth;
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _profileHandler = profileHandler;
        }

        public IActionResult Index( string ReturnUrl = null!)
        {
            var form = new RegisterForm { ReturnUrl = ReturnUrl ?? Url.Content("~/") };
            return View(form);
        }

        [HttpPost]
        public async Task <IActionResult> RegisterR(RegisterForm form)
        {
            if(ModelState.IsValid)
            {
                if(await _userManager.Users.AnyAsync(x=> x.Email == form.Email))
                {
                    ModelState.AddModelError(string.Empty, "Email is already being used");
                    return View(form);
                }
               // await _auth.RegisterAsync(form);

                if (await _auth.RegisterAsync(form))
                    return LocalRedirect(form.ReturnUrl!);
                else
                    return View(form);

            }
            return View(form);
        }

        //B

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                if (await _userManager.Users.AnyAsync(x => x.Email == form.Email))
                {
                    ModelState.AddModelError(string.Empty, "Email already exists");
                    return View(form);
                }

                var IdentityUser = new IdentityUser
                {
                    Email = form.Email,
                    UserName = form.Email,
                };

                var result = await _userManager.CreateAsync(IdentityUser, form.Password);
                if (result.Succeeded)
                {
                    var profileEntity = new ProfileEntity()
                    {
                        UserId = IdentityUser.Id,
                        FirstName = form.FirstName,
                        LastName = form.LastName,
        
                    };


                    var resultr = new IdentityUserProfile
                    {

                        UserId = IdentityUser.Id,
                        FirstName = form.FirstName,
                        LastName = form.LastName,
                        StreetName = form.StreetName ?? null!,
                        PostalCode = form.PostalCode ?? null!,
                        City = form.City ?? null!,
                        Company = form.Company ?? null!,
                    };
                    _context.userProfiles.Add(new IdentityUserProfile
                    {


                        UserId = IdentityUser.Id,
                        FirstName = form.FirstName,
                        LastName = form.LastName,
                        StreetName = form.StreetName ?? null!,
                        PostalCode = form.PostalCode ?? null!,
                        City = form.City ?? null!,
                        Company = form.Company ?? null!,


                    }) ;

              var resulttr = await _context.SaveChangesAsync();

                    _context.Add(profileEntity);
                    await _context.SaveChangesAsync();

                 

                    var signInResult = await _signInManager.PasswordSignInAsync(IdentityUser, form.Password, false, false);
                    if (signInResult.Succeeded)
                        return LocalRedirect(form.ReturnUrl);
                    else RedirectToAction("/Login");

                }
            }
            ModelState.AddModelError(string.Empty, "Unable to create an account");
            return View(form);
        }





        //E
        [Authorize]
        public async Task <IActionResult> Index()
        {
            var viewModel = new IndexViewModelHans();
            viewModel.Profile = await _profileHandler.GetProfileAsync(User.Identity!.Name!);

            return View(viewModel);
        }

    }
}
