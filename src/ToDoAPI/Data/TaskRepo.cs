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
            return _taskContext.Tasks.ToList();
        }
        public void DeleteTask() { return; }
        public void AddTask() { return; }
        public void UpdateTask() { return; }
    }
}