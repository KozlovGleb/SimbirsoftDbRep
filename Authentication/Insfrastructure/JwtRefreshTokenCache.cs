using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Authentication.Insfrastructure
{
    /// <summary>
    /// Кэш рефреш токена.
    /// </summary>
    public class JwtRefreshTokenCache:IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IJwtAuthManager _jwtAuthManager;

        /// <summary>
        /// Initialize <see cref="JwtRefreshTokenCache"/>
        /// </summary>
        /// <param name="jwtAuthManager"><see cref="IJwtAuthManager"/></param>
        public JwtRefreshTokenCache(IJwtAuthManager jwtAuthManager)
        {
            _jwtAuthManager = jwtAuthManager;
        }

        /// <summary>
        /// Remove old tokens.
        /// </summary>
        /// <param name="stoppingToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken stoppingToken)
        {
            // remove expired refresh tokens from cache every minute
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        /// <summary>
        /// Remove action.
        /// </summary>
        private void DoWork(object state)
        {
            _jwtAuthManager.RemoveExpiredRefreshTokens(DateTime.Now);
        }

        /// <summary>
        /// Stop removing.
        /// </summary>
        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Dispose timer.
        /// </summary>
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
