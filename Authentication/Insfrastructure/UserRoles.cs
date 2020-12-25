using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Authentication.Insfrastructure
{
    /// <summary>
    /// Роли при авторизации.
    /// </summary>
    public class UserRoles
    {
        /// <summary>
        /// Admin role.
        /// </summary>
        public const string Admin = nameof(Admin);

        /// <summary>
        /// Default role.
        /// </summary>
        public const string Default = nameof(Default);
    }
}
