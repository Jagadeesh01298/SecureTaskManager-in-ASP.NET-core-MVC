using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using SecureTaskManager.Models;

namespace SecureTaskManager.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create default Admin
            string adminEmail = "admin@gmail.com";
            string adminPassword = "Admin123";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "Default Admin",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminUser, adminPassword);
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Create default normal User
            string userEmail = "user@gmail.com";
            string userPassword = "User123";

            var normalUser = await userManager.FindByEmailAsync(userEmail);

            if (normalUser == null)
            {
                normalUser = new ApplicationUser
                {
                    UserName = userEmail,
                    Email = userEmail,
                    FullName = "Default User",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(normalUser, userPassword);
                await userManager.AddToRoleAsync(normalUser, "User");

                // Add claim CanEditTask
                await userManager.AddClaimAsync(normalUser, new Claim("CanEditTask", "true"));
            }
        }
    }
}
