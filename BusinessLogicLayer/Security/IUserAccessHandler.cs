using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Security
{
    public interface IUserAccessHandler
    {
        bool Authenticate(string userName, string password);

        User GetUserDetails(int userId);
    }
}
