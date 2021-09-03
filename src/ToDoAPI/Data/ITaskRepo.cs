using ToDoAPI.Models;
using System.Collections.Generic;


namespace ToDoAPI.Data
{
    public interface ITaskRepo
    {
        int SaveChanges();
        IEnumerable<Tasks> GetTasks();
        void DeleteTask(int id);
        void AddTask(Tasks task);
        void UpdateTask();
        Tasks GetTaskById(int id);

    }
}