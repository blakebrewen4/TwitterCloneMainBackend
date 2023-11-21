using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TwitterCloneAPIUserAuth2._0.Data;
using TwitterCloneAPIUserAuth2._0.Repositories;
using TwitterCloneAPIUserAuth2._0.Models;
using TwitterCloneShared.SharedModels;

namespace TwitterCloneAPIUserAuth2._0.Services
{
    public class AuthenticationService
    {
        private readonly UserRepository _userRepository;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(
            UserRepository userRepository,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IOptions<JwtSettings> jwtSettings)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<bool> ValidateCredentials(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);
            if (user == null)
            {
                return false;
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<string?> GenerateJwtToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
