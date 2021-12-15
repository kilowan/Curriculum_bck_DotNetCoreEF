using curriculum.Data;
using curriculum.Models;
using curriculum.Models.Employee;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace curriculum.Business
{
    public class CredentialsBz : ICredentialsBz
    {
        private readonly ICredentialsData credentialsData;
        private readonly IConfiguration configuration;
        private readonly IUserBz userBz;
        public CredentialsBz(ICredentialsData credentialsData, IConfiguration configuration, IUserBz userBz)
        {
            this.credentialsData = credentialsData;
            this.configuration = configuration;
            this.userBz = userBz;
        }

        public bool CheckCredentials(string username, string password)
        {
            try
            {
                return credentialsData.CheckCredentials(username, password);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string Login(string username, string password)
        {
            try
            {
                string result = "False";
                bool userExist = credentialsData.CheckCredentials(username, password);
                if (userExist)
                {
                    User user = userBz.GetUserByUsername(username);
                    result = MakeTokenJWT(user);
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool CheckUsername(string username)
        {
            try
            {
                return credentialsData.CheckUsername(username);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdatePassword(CredentialsDto creds, string code)
        {
            try
            {
                return credentialsData.UpdatePassword(creds, code);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private string MakeTokenJWT(User usuarioInfo)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.userId.ToString()),
                new Claim("nombre", usuarioInfo.name),
                new Claim("apellidos", $"{usuarioInfo.surname1} {usuarioInfo.surname2}"),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.emailList[0].fullEmail)
            };

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddHours(24)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}
