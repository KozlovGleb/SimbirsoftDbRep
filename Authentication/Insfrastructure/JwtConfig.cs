using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Authentication.Insfrastructure
{
    /// <summary>
    /// Конфигурация JWT.
    /// </summary>
    public class JwtConfig
    {
        /// <summary>
        /// Secret.
        /// </summary>
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Issuer.
        /// </summary>
        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// Audience.
        /// </summary>
        [JsonPropertyName("audience")]
        public string Audience { get; set; }

        /// <summary>
        /// AT time.
        /// </summary>
        [JsonPropertyName("accessTokenExpiration")]
        public int AccessTokenExpiration { get; set; }

        /// <summary>
        /// RT time.
        /// </summary>
        [JsonPropertyName("refreshTokenExpiration")]
        public int RefreshTokenExpiration { get; set; }
    }
}

