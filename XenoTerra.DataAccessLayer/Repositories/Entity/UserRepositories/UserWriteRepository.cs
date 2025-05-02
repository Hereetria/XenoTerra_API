using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.UserRepository
{
    public class UserWriteRepository(UserManager<User> userManager) : IUserWriteRepository
    {
        private readonly UserManager<User> _userManager = userManager;

        public async Task<User> InsertAsync(User user, string password)
        {
            ArgumentGuard.EnsureNotNull(user);
            ArgumentGuard.EnsureNotNull(password);

            var result = await _userManager.CreateAsync(user, password);
            EnsureSuccess(result, "User creation failed");

            return user;
        }

        public async Task<User> ModifyAsync(User user, IEnumerable<string> modifiedFields)
        {
            ArgumentGuard.EnsureNotNull(user);

            var existingUser = await _userManager.FindByIdAsync(user.Id.ToString())
                ?? throw new KeyNotFoundException($"User with ID '{user.Id}' not found.");

            var userType = typeof(User);
            var modifiedSet = new HashSet<string>(modifiedFields, StringComparer.OrdinalIgnoreCase);

            foreach (var prop in userType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (modifiedSet.Contains(prop.Name) && prop.CanWrite)
                {
                    var newValue = prop.GetValue(user);
                    prop.SetValue(existingUser, newValue);
                }
            }

            var result = await _userManager.UpdateAsync(existingUser);
            EnsureSuccess(result, "Failed to update user");

            return existingUser;
        }

        public async Task<User> RemoveAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString())
                ?? throw new KeyNotFoundException($"User with ID '{id}' not found.");

            var result = await _userManager.DeleteAsync(user);
            EnsureSuccess(result, "User deletion failed");

            return user;
        }

        private static void EnsureSuccess(IdentityResult result, string message)
        {
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new InvalidOperationException($"{message}: {string.Join(", ", errors)}");
            }
        }
    }
}
