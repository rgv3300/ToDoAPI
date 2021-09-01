using ToDoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ToDoAPI.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserRepo(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IdentityResult> LoginUser(TaskUser taskUser)
        {
            var user = new IdentityUser { UserName = taskUser.Email, Email = taskUser.Email };
            var result = await userManager.CreateAsync(user, taskUser.Password);
        }
    }
}