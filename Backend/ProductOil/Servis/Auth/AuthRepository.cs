using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductOil.Data;
using ProductOil.Dto;
using ProductOil.Enitiy;
using System.Security.Claims;

namespace ProductOil.Servis.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager;
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> userManager;
        public AuthRepository(AppDbContext appDbContext, Microsoft.AspNetCore.Identity.UserManager<User> userManager, Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<string> Login(UserDto userDto)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync(i => i.Email == userDto.Email);
            if (user != null)
            {
                var roles = await userManager.GetRolesAsync(user);
                var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
                roleClaims.Add(new Claim(ClaimTypes.Name, userDto.Name));
                var token = CreateTokenInJwtAuthorizationFromUsers.CreateToken(user, roleClaims);
                return token;
            }
            throw new BadHttpRequestException("User not found.");
        }

        public async Task<User> Register(UserDto userDto)
        {
            var user = new User
            {
                UserName = userDto.Name,
                Email = userDto.Email
            };

            var result = await userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                throw new Exception("Password isn't hashed");
            }


            await userManager.AddToRoleAsync(user, Enum.GetName(userDto.Role).ToUpper());
            await appDbContext.SaveChangesAsync();
            return user;
        }
        public async Task<List<User>> GetAllUsers() => await appDbContext.Users.ToListAsync();
    }
}
