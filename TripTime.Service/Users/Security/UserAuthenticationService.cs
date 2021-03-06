﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TripTime.Data.Repositories;
using TripTime.Domain.Users;

namespace TripTime.Service.Users.Security
{
    public class UserAuthenticationService
    {
        public IConfiguration _configuration;

        private readonly UserRepository _userRepository;
        private readonly Hasher _hasher;
        private readonly Salter _salter;

        public UserAuthenticationService(UserRepository userRepository, Hasher hasher, Salter salter, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _hasher = hasher;
            _salter = salter;
            _configuration = configuration;
        }

        public async Task<JwtSecurityToken> Authenticate(string providedEmail, string providedPassword)
        {
            User foundUser = await _userRepository.FindByEmail(providedEmail);
            if (foundUser == null)
            {
                return null;
            }
            if (IsSuccessfullyAuthenticated(providedEmail, providedPassword, foundUser.SecurePassword))
            {
                return new JwtSecurityTokenHandler().CreateToken(CreateTokenDescription(foundUser)) as JwtSecurityToken;
            }
            return null;
        }

        public async Task<User> GetCurrentLoggedInUser(ClaimsPrincipal principleUser)
        {
            var emailOfAuthenticatedUser = principleUser.FindFirst(ClaimTypes.Email)?.Value;
            return await _userRepository.FindByEmail(emailOfAuthenticatedUser);
        }

        public UserSecurity CreateUserSecurity(string userPassword)
        {
            var saltToBeUsed = _salter.CreateRandomSalt();
            return new UserSecurity(
                _hasher.CreateHashOfPasswordAndSalt(userPassword, saltToBeUsed),
                saltToBeUsed);
        }

        private SecurityTokenDescriptor CreateTokenDescription(User foundUser)
        {
            var user = foundUser;
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, foundUser.FirstName),
                    new Claim(ClaimTypes.Email, foundUser.Email.Address),
                    new Claim(ClaimTypes.Role, foundUser.GetType().Name.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(GetSecretKey(_configuration["SecretKey"])),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenDescriptor;
        }

        private bool IsSuccessfullyAuthenticated(string providedEmail, string providedPassword, UserSecurity persistedUserSecurity)
        {
            return _hasher.DoesProvidedPasswordMatchPersistedPassword(providedPassword, persistedUserSecurity);
        }


        public static byte[] GetSecretKey(string localSecretKey)
        {
            if (IsSecretKeySetForRemoteServer())
            {
                return Encoding.ASCII.GetBytes(GetSecretKeyForRemoteServer());
            }
            if (IsSecretKeySetForContinuousIntegration())
            {
                return Encoding.ASCII.GetBytes(GetSecretKeyForContinuousIntegration());
            }
            if (IsSecretKeyForLocalDevelopment(localSecretKey))
            {
                return Encoding.ASCII.GetBytes(localSecretKey);
            }
            else
            {
                return Encoding.ASCII.GetBytes("DummySecretThatIsNotThatSecretButLongEnough");
            }
        }

        private static bool IsSecretKeyForLocalDevelopment(string localSecretKey)
        {
            return string.IsNullOrEmpty(localSecretKey) != true;
        }

        private static bool IsSecretKeySetForContinuousIntegration()
        {
            return string.IsNullOrEmpty(GetSecretKeyForContinuousIntegration()) != true;
        }

        private static bool IsSecretKeySetForRemoteServer()
        {
            return string.IsNullOrEmpty(GetSecretKeyForRemoteServer()) != true;
        }

        private static string GetSecretKeyForContinuousIntegration()
        {
            return Environment.GetEnvironmentVariable("SecretKey", EnvironmentVariableTarget.Machine);
        }

        private static string GetSecretKeyForRemoteServer()
        {
            return Environment.GetEnvironmentVariable("APPSETTING_SecretKey", EnvironmentVariableTarget.Process);
        }

    }
}
