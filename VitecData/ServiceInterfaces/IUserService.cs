using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VitecData.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> LoginUser(string username, string password);

        Task<bool> CreateNewUser(string username, string password, string firstName, string lastName, string address,
            int zip);

        Task SignOutUser();
    }
}
