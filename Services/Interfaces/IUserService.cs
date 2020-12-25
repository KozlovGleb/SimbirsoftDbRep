using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Services.Interfaces.Login
{
    public interface IUserService
    {
        /// <summary>
        /// Check user.
        /// </summary>
        bool IsAnExistingUser(string userName);

        /// <summary>
        /// Validate user data.
        /// </summary>
        bool IsValidUserCredentials(string userName, string password);

        /// <summary>
        /// Get user role if exists.
        /// </summary>
        string GetUserRole(string userName);
    }
}
