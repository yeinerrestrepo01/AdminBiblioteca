using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAdmin
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
    public class UserService: IUserService
    {
        /// <summary>
        /// usuario impicito para realizar pruebas
        /// </summary>
        private List<UserEntity> _users = new List<UserEntity>
        {
            new UserEntity { Id = 1, FirstName = "Manuel", LastName = "Daza", Username = "AdminBiblioteca", Password = "Admin123" }
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// metodo para autenticacion de usuarios.
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
            var useresult = new User { Username = user.Username, FirstName = user.FirstName, LastName  = user.LastName};
            // return null if user not found
            if (useresult == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            useresult.Token = tokenHandler.WriteToken(token);
            useresult.Expires = TimeSpan.FromHours(10).TotalMinutes;
            return useresult;
        }
    }
}
