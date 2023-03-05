using aspfinal.Context;
using aspfinal.Models.Forms;
using aspfinal.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace aspfinal.Services
{
    public class AuthServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IdentityContext _context;

        public AuthServices(UserManager<IdentityUser> userManager, IdentityContext context, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<bool> RegisterAsync(RegisterForm form)
        {
            var identityUser = new IdentityUser 
            { UserName = form.Email, 
                Email = form.Email,
                PhoneNumber = form.PhoneNumber 
            };
            var identityProfile = new IdentityUserProfile
            {
                UserId = identityUser.Id,
                FirstName = form.FirstName,
                LastName = form.LastName,
                StreetName = form.StreetName,
                PostalCode = form.PostalCode,
                City = form.City,
                Company = form.Company
            };
          var result = await _userManager.CreateAsync(identityUser, form.Password);
            if(result.Succeeded)
            {
                _context.userProfiles.Add(identityProfile);
                await _context.SaveChangesAsync();
                return true;
            }
          

            return false;
        }

        public async Task<bool> LoginAsync(LoginForm form, bool keepMeLoggedIn = false)
        {
            var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false);
             return result.Succeeded;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
