using System;
using System.Collections.Generic;
using System.Text;

namespace AceAutos.Core.ApplicationService
{
    public interface IUserService
    {
        String ValidateUser(Tuple<string, string> attemptToLogin);
    }
}
