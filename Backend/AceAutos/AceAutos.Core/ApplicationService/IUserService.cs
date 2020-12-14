using AceAutos.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Core.ApplicationService
{
    public interface IUserService
    {
        String ValidateUser(Tuple<string, string> attemptToLogin);
        User DeleteUser(int id);
        User EditUser(int id, User user);
        List<User> GetAllUsers();
    }
}
