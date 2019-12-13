using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VitecData;
using VitecData.Models;
using VitecData.ServiceInterfaces;

namespace VitecServices
{
    public class UserService : IUserService
    {
        private VitecContext _context;
        private UserManager<WebUser> _userManager;
        private SignInManager<WebUser> _signInManager;

        public UserService(VitecContext context, UserManager<WebUser> userManager, SignInManager<WebUser> signInManager)
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

        public async Task<IdentityResult> CreateNewUser(string username, string email, string password, string firstName,
            string lastName, string address, int zip)
        {
            var result = await _userManager.CreateAsync(new WebUser
            {
                UserName = username,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                ZIP = zip
            }, password);

            return result;
        }

        public async Task SignOutUser()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IEnumerable<WebUser>> GetAllUsers()
        {
            return  _userManager.Users.ToList();
        }
    }
}
