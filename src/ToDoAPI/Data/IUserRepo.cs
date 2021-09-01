using ToDoAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoAPI.Data
{
    public interface IUserRepo
    {
        Task<IdentityResult> LoginUser(TaskUser taskUser);
        void RegisterUser(TaskUser taskUser);
        void LogoutUser(TaskUser taskUser);
    }
}