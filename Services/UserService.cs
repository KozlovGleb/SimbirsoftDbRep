using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimbirsoftDbRep.Database.Context;
using SimbirsoftDbRep.Services.Interfaces.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Services
{
    public class UserService:IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly HospitalContext _jwtContext;

        /// <summary>
        /// Initialize <see cref="UserService"/>
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">DB Context.</param>
        public UserService(ILogger<UserService> logger, HospitalContext context)
        {
            _logger = logger;
            _jwtContext = context;
        }

        /// <inheritdoc />
        public bool IsValidUserCredentials(string userName, string password)
        {
            _logger.LogInformation($"Validating user [{userName}]");
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            return _jwtContext.Users.Any(x => x.Login == userName && x.Password == password);
        }

        /// <inheritdoc />
        public bool IsAnExistingUser(string userName)
        {
            return _jwtContext.Users.Any(x => x.Login == userName);
        }

        /// <inheritdoc />
        public string GetUserRole(string userName)
        {
            if (!IsAnExistingUser(userName))
            {
                return string.Empty;
            }

            var role = _jwtContext.UserRoles
                .Include(x => x.User)
                .Include(x => x.Role)
                .SingleOrDefault(x => x.User.Login == userName).Role?.Name;

            if (string.IsNullOrEmpty(role))
                throw new ArgumentNullException("Can't find role.");

            return role;
        }
    }
}
