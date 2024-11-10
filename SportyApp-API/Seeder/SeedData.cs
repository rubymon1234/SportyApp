using Microsoft.AspNetCore.Identity;

namespace SportyApp.Seeder
{
    public class SeedData
    {
        public static async Task SeedRole(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new List<IdentityRole>
            {
                new IdentityRole{Name="MasterAdmin",NormalizedName="MasterAdmin"},
                new IdentityRole{Name="Admin",NormalizedName="Admin"},
                new IdentityRole{Name="User",NormalizedName="User"},
            };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role.Name))
                {
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}
