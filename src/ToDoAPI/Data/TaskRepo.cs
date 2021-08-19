using ToDoAPI.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
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
        public void DeleteTask(Task task)
        {
            if (_taskContext.Tasks.Any(t => t.ID == task.ID))
            {
                _taskContext.Tasks.Remove(task);
            }
            else
            {
                throw new ArgumentException("No such task exists.");
            }
        }
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