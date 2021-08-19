using ToDoAPI.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ToDoAPI.Data
{
    public class TaskRepo : ITaskRepo
    {
        private readonly TaskContext _taskContext;
        public TaskRepo(TaskContext myTaskContext)
        {
            _taskContext = myTaskContext;
        }
        public IEnumerable<Task> GetTasks()
        {
            return _taskContext.Tasks;
        }
        public void DeleteTask() { return; }
        public void AddTask(Task task)
        {
            try
            {
                _taskContext.Tasks.Add(task);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public int SaveChanges()
        {
            return _taskContext.SaveChanges();
        }
        public void UpdateTask() { return; }

    }
}