using aspfinal.Context;
using aspfinal.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace aspfinal.Services
{
    public class UserServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentityContext _context;

        public UserServices(UserManager<IdentityUser> userManager, IdentityContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<UserAccount> GetUserAccountAsync(string id)
        {
            var identityUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(identityUser != null)
            {
                var identityProfile = await _context.userProfiles.FirstOrDefaultAsync(x => x.UserId == identityUser.Id); 

                if(identityProfile != null)
                {
                    return new UserAccount
                    {
                        Id = identityUser.Id,
                        FirstName = identityProfile.FirstName,
                        LastName = identityProfile.LastName,
                        Email = identityUser.Email!,
                        PhoneNumber = identityUser.PhoneNumber,
                        StreetName = identityProfile.StreetName,
                        PostalCode = identityProfile.PostalCode,
                        City = identityProfile.City,
                        Company = identityProfile.Company
                    };
                }
            }
            return null!;

        }


    }
}
