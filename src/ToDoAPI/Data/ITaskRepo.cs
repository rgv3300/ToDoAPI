using ToDoAPI.Models;
using System.Collections.Generic;


namespace ToDoAPI.Data
{
    public interface ITaskRepo
    {
        int SaveChanges();
        IEnumerable<Task> GetTasks();
        void DeleteTask(Task task);
        void AddTask(Task task);
        void UpdateTask();


    }
}