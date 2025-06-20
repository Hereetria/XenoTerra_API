using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Concrete;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.AppRoleRepositories
{
    public class AppRoleWriteRepository(RoleManager<AppRole> roleManager) : IAppRoleWriteRepository
    {
        private readonly RoleManager<AppRole> _roleManager = roleManager;

        public async Task<AppRole> InsertAsync(AppRole role)
        {
            ArgumentGuard.EnsureNotNull(role);

            var result = await _roleManager.CreateAsync(role);
            EnsureSuccess(result, "Role creation failed");

            return role;
        }

        public async Task<AppRole> ModifyAsync(AppRole role, IEnumerable<string> modifiedFields)
        {
            ArgumentGuard.EnsureNotNull(role);

            var existing = await _roleManager.FindByIdAsync(role.Id.ToString())
                ?? throw new KeyNotFoundException($"Role with ID '{role.Id}' not found."); ;

            ApplyModifiedFields(existing, role, modifiedFields);

            var result = await _roleManager.UpdateAsync(existing);
            EnsureSuccess(result, "Failed to update role");

            return existing;
        }

        public async Task<AppRole> RemoveAsync(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString())
                ?? throw new KeyNotFoundException($"Role with ID '{id}' not found."); ;

            var result = await _roleManager.DeleteAsync(role);
            EnsureSuccess(result, "Role deletion failed");

            return role;
        }

        private static void ApplyModifiedFields(
            AppRole target,
            AppRole source,
            IEnumerable<string> modifiedFields)
        {
            var modifiedSet = new HashSet<string>(modifiedFields, StringComparer.OrdinalIgnoreCase);
            var props = typeof(AppRole).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                if (modifiedSet.Contains(prop.Name) && prop.CanWrite)
                {
                    var newValue = prop.GetValue(source);
                    prop.SetValue(target, newValue);
                }
            }
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
