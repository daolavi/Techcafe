using Amazon.Lambda.Core;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TechCafe.Repository;
using TechCafe.Repository.Entities;

namespace TechCafe.Api.Services
{
    public interface IAuthenticationService
    {
        Models.UserModel Authenticate(string username, string password);

        string BuildToken(Models.UserModel account);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private IConfiguration config;

        private TechCafeDbContext dbContext;

        private IMapper mapper;

        private IPasswordHasher<User> passwordHasher;

        public AuthenticationService(IConfiguration config, TechCafeDbContext dbContext, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            this.config = config;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
        }

        public Models.UserModel Authenticate(string username, string password)
        {
            LambdaLogger.Log(dbContext.ToString());
            var accountEntity = dbContext.Users.FirstOrDefault(x => x.Username == username);
            Models.UserModel accountModel = null; 
            if (accountEntity != null)
            {
                var verifyResult = passwordHasher.VerifyHashedPassword(accountEntity, accountEntity.Password, password);
                if (verifyResult == PasswordVerificationResult.Success)
                {
                    accountModel = mapper.Map<Models.UserModel>(accountEntity);
                }
            }
            return accountModel;
        }

        public string BuildToken(Models.UserModel account)
        {
            var claims = new[] 
            {
                new Claim(TechCafeClaimNames.AccountId,account.Id.ToString()),
                new Claim(TechCafeClaimNames.Username,account.Username),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                                            config["Jwt:Issuer"],
                                            claims,
                                            expires: DateTime.Now.AddMinutes(30),
                                            signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
