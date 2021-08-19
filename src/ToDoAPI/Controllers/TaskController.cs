using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Data;
using System.Collections.Generic;
using ToDoAPI.Models;
using System.Net.Http;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/Tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepo _myTask;
        public TaskController(ITaskRepo myTask)
        {
            _myTask = myTask;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Task>> Get()
        {
            return Ok(_myTask.GetTasks());
        }
        [HttpPost]
        public ActionResult<Task> Create(Task task)
        {
            if (ModelState.IsValid)
            {
                _myTask.AddTask(task);
                _myTask.SaveChanges();
                return CreatedAtAction(nameof(Get), task);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}