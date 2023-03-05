using aspfinal.Context;
using aspfinal.Models.Identitytestio;
using Microsoft.EntityFrameworkCore;


namespace aspfinal.Services
{
    public class ProfileHandler
    {
        private readonly IdentityContext _context;

        public ProfileHandler(IdentityContext context)
        {
            _context = context;
        }

        public async Task<Profile> GetProfileAsync(string userName)
        {
            var identityUser = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if (identityUser != null)
            {
                var ProfileEntity = await _context.userProfiles.FirstOrDefaultAsync(x => x.UserId == identityUser.Id);

                if (ProfileEntity != null)
                {
                    var profile = new Profile
                    {
                        UserId = identityUser.Id,
                        FirstName = ProfileEntity.FirstName,
                        LastName = ProfileEntity.LastName,
                        Email = identityUser.Email!,
                        PhoneNumber = identityUser.PhoneNumber


                    };
                    return profile;
                }
            }
            return null!;
        }
    }
    }
