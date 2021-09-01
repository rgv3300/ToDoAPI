using ToDoAPI.Models;
using System.Collections.Generic;

namespace ToDoAPI.Data
{
    public interface IUserRepo
    {
        void LoginUser(TaskUser taskUser);
        void RegisterUser(TaskUser taskUser);
        void LogoutUser(TaskUser taskUser);
    }
}