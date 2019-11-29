using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VitecData.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> LoginUser(string username, string password);

        Task<IdentityResult> CreateNewUser(string username, string email, string password, string firstName, string lastName, string address,
            int zip);

        Task SignOutUser();
    }
}
