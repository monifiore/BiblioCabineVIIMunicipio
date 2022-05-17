using LegArtiCommon;
using LegArtiModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LegArtiCore
{
    /// <summary>
    /// Classe che implementa la logica di gestione del Token
    /// </summary>
    /*public class TokenCore : BaseCore
    {
        private static readonly string TOKEN_KEY = "Itk.Security.Key";
        /// <summary>
        /// Aggiorna il Token
        /// </summary>
        /// <param name="_token">Il (refresh) Token</param>
        /// <returns>Il nuovo Token</returns>
        public TokenModel Refresh(string _token)
        {
            TokenModel _ret = new TokenModel();
            // mi estraggo dal token il refresh e aggiorno il token e la tabella con i  nuovi dati
            return _ret;
        }
        /// <summary>
        /// Inserisce il Token
        /// </summary>
        /// <param name="_payload">Stringa con le informazioni</param>
        /// <returns>Il Token generato</returns>
        public TokenModel Insert(UtenteModel _user)
        {
            TokenModel _tokenModel = generateJwtToken(_user);
            try
            {
                genericDal.ExecuteNonQuery("Token_Insert", new Dictionary<string, object>
                {
                    { "Token", _tokenModel.Token },
                    { "RefreshToken", _tokenModel.RefreshToken },
                    { "ReleaseDate", _tokenModel.ReleaseDate },
                    { "ExpirationDate", _tokenModel.ExpirationDate },
                    { "IdUser", _user.IDUtente}
                });
            }
            catch (ExceptionLogin ex)
            {
                throw ex;
            }
            return _tokenModel;
        }

        /// <summary>
        /// Metodo per la generazione del Token
        /// </summary>
        /// <param name="payload">Il payload del token</param>
        /// <param name="roles">I ruoli utente da inserire in claims appositi</param>
        /// <param name="minute">I minuti di scadenza del token (default 15)</param>
        /// <returns>L'oggetto Token serializzato</returns>
        public static string Generate(string payload, List<string> roles, int minute = 24)
        {
            DateTime _expirationDate = DateTime.Now.AddMinutes(minute);
            JwtSecurityTokenHandler _tokenHandler = new();
            byte[] _key = Encoding.ASCII.GetBytes(TOKEN_KEY);
            SecurityTokenDescriptor _tokenDescriptor = new()
            {
                Claims = new Dictionary<string, object>(),
                Subject = new ClaimsIdentity(new[] { new Claim("user", payload) }),
                Expires = _expirationDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken _token = _tokenHandler.CreateToken(_tokenDescriptor);

            return JsonSerializer.Serialize(new TokenModel
            {
                Token = _tokenHandler.WriteToken(_token),
                RefreshToken = generateRefreshToken(),
                ReleaseDate = DateTime.Now,
                ExpirationDate = _expirationDate
            });

            static string generateRefreshToken()
            {
                using RNGCryptoServiceProvider _rngCryptoServiceProvider = new();
                byte[] _randomBytes = new byte[64];
                _rngCryptoServiceProvider.GetBytes(_randomBytes);
                return Convert.ToBase64String(_randomBytes);
            }
        }

        /// <summary>
        /// Fornisce i parametri per la validazione del Token
        /// </summary>
        /// <returns>I parametri di validazione</returns>
        public static TokenValidationParameters ValidationParameters() => new()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TOKEN_KEY)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };

        /// <summary>
        /// Deserializza un token e lo converto nel modello utilizzato
        /// </summary>
        /// <param name="token">Il token da deserializzare</param>
        /// <returns>Il modello valorizzato oppure il modello vuoto se la deserializzazione non va a buon fine</returns>
        public static T Deserialize<T>(string token)
        {
            try
            {
                JwtSecurityTokenHandler _jwtSecurityTokenHandler = new();
                JwtSecurityToken _jwtSecurityToken = _jwtSecurityTokenHandler.ReadJwtToken(token);
                Claim _claimUser = _jwtSecurityToken.Claims.Where(x => x.Type == "user").FirstOrDefault();
                return JsonSerializer.Deserialize<T>(_claimUser.Value);
            }
            catch (Exception)
            {
                return default;
            }
        }



    }*/
}
