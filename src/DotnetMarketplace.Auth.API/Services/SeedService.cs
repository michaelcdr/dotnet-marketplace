using DotnetMarketplace.Auth.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotnetMarketplace.Auth.API.Services
{
    public class SeedService : ISeedService, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedService(ApplicationDbContext context,
                           UserManager<IdentityUser> userManager,
                           RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Executar()
        {
            if (!await _context.Roles.AnyAsync(r => r.Name == "admin"))
            {
                _context.Roles.Add(new IdentityRole("admin"));
                _context.SaveChanges();
            }

            if (!await _context.Roles.AnyAsync(r => r.Name == "comum"))
            {
                _context.Roles.Add(new IdentityRole("comum"));
                await _context.SaveChangesAsync();
            }

            if (!await _context.Roles.AnyAsync(r => r.Name == "vendedor"))
            {
                _context.Roles.Add(new IdentityRole("vendedor"));
                await _context.SaveChangesAsync();
            }

            if (!await _context.Users.AnyAsync(e => e.UserName == "michael"))
            {
                var result = await _userManager.CreateAsync(new IdentityUser("michael"));

                if (result.Succeeded)
                {
                    var user = await _context.Users.SingleAsync(e => e.UserName == "michael");
                    await _userManager.AddToRoleAsync(user, "admin");
                }
            }
        }
    }
}