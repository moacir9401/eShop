using eshop.IdentityServer.Configuration;
using eshop.IdentityServer.Model;
using eshop.IdentityServer.Model.Context;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace eshop.IdentityServer.Initializer
{
    public class DbIntializer : IDbIntializer
    {
        private readonly MySqlContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private RoleManager<IdentityRole> _role;

        public DbIntializer(MySqlContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;

            _role.CreateAsync(
                new IdentityRole(IdentityConfiguration.Admin))
                .GetAwaiter()
                .GetResult();
            
            _role.CreateAsync(
                new IdentityRole(IdentityConfiguration.Client))
                .GetAwaiter()
                .GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "Moacir-admin",
                Email = "moacir-admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (31) 98877-5598",
                FirstName = "Moacir",
                LastName = "Admin"
            };

            _user.CreateAsync(admin,"Admin123@").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin, 
                IdentityConfiguration.Admin).GetAwaiter().GetResult();

            var adminCllaims = _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin),
            }).Result;

            ApplicationUser client = new ApplicationUser()
            {
                UserName = "Moacir-client",
                Email = "moacir-client@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (31) 98877-5598",
                FirstName = "Moacir",
                LastName = "client"
            };

            _user.CreateAsync(client, "Admin123@").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client,
                IdentityConfiguration.Client).GetAwaiter().GetResult();

            var clientCllaims = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client),
            }).Result;

        }
    }
}
