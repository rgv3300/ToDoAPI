using ToDoAPI.Models.Users;


namespace ToDoAPI.Data
{
    public interface IUserRepo
    {
        TaskUser GetById(int id);
        TaskUserResponse Authenticate(TaskUserRequest taskUser);
        void Register(TaskUserRegister taskUser);
        void Update(int id, TaskUserUpdate taskUser);
        void Delete(int id);
    }
}