using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Data;
using System.Collections.Generic;

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
        public ActionResult Get()
        {
            return Ok(_myTask.GetTasks());
        }
    }
}