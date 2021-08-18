using ToDoAPI.Models;
using System.Collections.Generic;


namespace ToDoAPI.Data
{
    public interface ITaskRepo
    {
        IEnumerable<Task> GetTasks();
        void DeleteTask();
        void AddTask();
        void UpdateTask();

    }
}