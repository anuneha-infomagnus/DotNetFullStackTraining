using Day16.Models;
using Microsoft.AspNetCore.Identity;

namespace Day16.Data;

public static class SeedData
{
    public static async Task InitializeAsync(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        // Create roles
        string[] roles = { "Admin", "Employee" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(
                    new IdentityRole(role));
            }
        }

        // Create Admin
        var admin = await userManager.FindByNameAsync("admin");

        if (admin == null)
        {
            admin = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@example.com",
                FullName = "System Administrator"
            };

            var result = await userManager.CreateAsync(
                admin,
                "Admin@123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(
                    admin,
                    "Admin");
            }
        }

        // Create Employee
        var employee =
            await userManager.FindByNameAsync("employee");

        if (employee == null)
        {
            employee = new ApplicationUser
            {
                UserName = "employee",
                Email = "employee@example.com",
                FullName = "Anuneha"
            };

            var result = await userManager.CreateAsync(
                employee,
                "Employee@123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(
                    employee,
                    "Employee");
            }
        }
    }
}