using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Auth.Inputs;
using XenoTerra.WebAPI.GraphQL.Auth.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Auth.Services
{
    public class AuthService(UserManager<User> userManager, IConfiguration config, IValidator<RegisterInput> registerValidator) : IAuthService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IConfiguration _config = config;
        private readonly IValidator<RegisterInput> _validator = registerValidator;

        public async Task<RegisterPayload> RegisterAsync(RegisterInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(RegisterInput));
            await ValidationGuard.ValidateOrThrowAsync(_validator, input);

            var newUser = new User
            {
                UserName = input.UserName,
                Email = input.Email,
                FullName = input.FullName,
                BirthDate = DateOnly.Parse(input.BirthDate).ToDateTime(),
                EmailConfirmed = true
            };

            var createResult = await _userManager.CreateAsync(newUser, input.Password);

            if (!createResult.Succeeded)
            {
                var errorMessages = string.Join(", ", createResult.Errors.Select(e => e.Description));
                throw GraphQLExceptionFactory.Create($"User creation failed: {errorMessages}");
            }

            await _userManager.AddToRoleAsync(newUser, "Visitor");

            var resultDto = new ResultUserPrivateDto
            {
                Id = newUser.Id,
                UserName = newUser.UserName!,
                Email = newUser.Email!,
                FullName = newUser.FullName,
                BirthDate = DateOnly.Parse(input.BirthDate).ToDateTime()
            };

            return Payload<ResultUserPrivateDto>.FromSuccess<RegisterPayload>(
                "User registered successfully",
                resultDto
            );
        }

        public async Task<LoginPayload> LoginAsync(LoginInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(LoginInput));

            if (string.IsNullOrWhiteSpace(input.Identity) || input.Identity.Length > 100)
                throw GraphQLExceptionFactory.Create("Invalid identity input.");

            User? user = null;

            if (input.Identity.Contains('@'))
            {
                user = await _userManager.FindByEmailAsync(input.Identity);
            }

            if (user == null && input.Identity.All(c => char.IsDigit(c) || c == '+'))
            {
                user = await _userManager.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.PhoneNumber == input.Identity);
            }

            user ??= await _userManager.FindByNameAsync(input.Identity);

            if (user == null)
                throw GraphQLExceptionFactory.Create("User not found.");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, input.Password);
            if (!isPasswordValid)
                throw GraphQLExceptionFactory.Create("Invalid credentials.");

            var userName = user.UserName ?? throw GraphQLExceptionFactory.Create("Username is missing for this account."); ;

            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Sub, user.Email ?? userName),
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, userName)
            };

            if (!string.IsNullOrWhiteSpace(user.Email))
                claims.Add(new Claim(ClaimTypes.Email, user.Email));

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            
            var issuer = _config["JwtSettings:Issuer"]
                ?? throw new InvalidOperationException("JWT Issuer is not configured.");
            var audience = _config["JwtSettings:Audience"]
                ?? throw new InvalidOperationException("JWT Audience is not configured.");
            var secretKey = _config["JwtSettings:SecretKey"]
                ?? throw new InvalidOperationException("JWT SecretKey is not configured.");


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var expires = DateTime.UtcNow.AddDays(7);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new LoginPayload(
                tokenString,
                expires,
                user.Id,
                userName
            );
        }
    }
}
