using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VitecData;
using VitecData.Migrations;
using VitecData.ServiceInterfaces;

namespace VitecServices
{
    public class UserService : IUserService
    {
        private VitecContext _context;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public UserService(VitecContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> LoginUser(string username, string password)
        {
            // Remember to edit the last "false" to implement lockoutOnFailure
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            return result.Succeeded;
        }
    }
}
