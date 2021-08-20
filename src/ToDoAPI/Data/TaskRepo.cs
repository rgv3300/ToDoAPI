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
        public void DeleteTask(int id)
        {
            var TaskExists = _taskContext.Tasks.Find(id);
            if (TaskExists.ID == id)
            {
                _taskContext.Tasks.Remove(TaskExists);
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
        public Task GetTaskById(int id)
        {
            return _taskContext.Tasks.Find(id);
        }
        public void UpdateTask() { return; }
    }
}